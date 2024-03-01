using UnityEngine;

public class CubeStateMachine : MonoBehaviour
{
    public enum CubeState
    {
        IDLE,
        WALK,
        BACK,
        JUMP
    }

    private Rigidbody rb;
    private CubeState currentState;

    public float walkSpeed = 5f;
    public float jumpForce = 10f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentState = CubeState.IDLE;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            currentState = CubeState.WALK;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            currentState = CubeState.BACK;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        UpdateMovement();
    }

    private void UpdateMovement()
    {
        switch (currentState)
        {
            case CubeState.IDLE:
                break;
            case CubeState.WALK:
                transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);
                break;
            case CubeState.BACK:
                transform.Translate(Vector3.back * walkSpeed * Time.deltaTime);
                break;
        }

        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            currentState = CubeState.IDLE;
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
