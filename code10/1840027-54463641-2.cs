    [SerializeField] private float rotationspeed;
    private void FixedUpdate()
    {
        // rotate around global world Y
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * rotationspeed * Time.deltaTime, Space.World);
        // rotate around local X
        transform.Rotate(-Vector3.right * Input.GetAxis("Mouse Y") * rotationspeed * Time.deltaTime);
    }
