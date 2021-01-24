    [SerializeField] private float rotationspeed;
    private void FixedUpdate()
    {
        // rotate around global world Y
        transform.Rotate(Input.GetAxis("Mouse X") * rotationspeed * Time.deltaTime, 0, 0, Space.World);
        // rotate around local X
        transform.Rotate(0, -Input.GetAxis("Mouse Y") * rotationspeed * Time.deltaTime, 0);
    }
