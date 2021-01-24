    void Update()
    {
        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        Vector3 lookDirection = moveDirection + gameObject.Transform.Position;
        gameObject.Transform.LookAt(lookDirection);
    }
