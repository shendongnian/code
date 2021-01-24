    [SerializeField] private float rotationspeed;
    private void FixedUpdate()
    {
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * rotationspeed * Time.deltatime, Space.World);
        transform.Rotate(-Vector3.right * Input.GetAxis("Mouse Y") * rotationspeed * Time.deltaTime);
    }
