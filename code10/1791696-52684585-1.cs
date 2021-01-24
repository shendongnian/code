    // How long in seconds will it take the lerps to finish moving into position
    public float lerpSmoothingTime = 0.1f;
    private Vector3 targetPosition;
    private Quaternion targetRotation;
    void Update()
    {
        bool running = Input.GetKey(KeyCode.LeftShift);
    
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
    
        bool isWalking = Mathf.Abs(h) + Mathf.Abs(v) > 0;
    
        movement = ((running) ? runSpeed : walkSpeed) * new Vector3(h, 0.0f, v).normalized;
        if (isWalking)
        {
            targetPosition += movement * Time.deltaTime;
            targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
        }
        // Always lerping as if we suddenly stopped the lerp as isWalking became false the stop would be sudden rather than smoothly moving into position/rotation
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime / lerpSmoothingTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime / lerpSmoothingTime);    
    }
