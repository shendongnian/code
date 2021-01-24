    public Transform rotationTarget;
    public bool flipRot = true;
    
    void Update()
    {
        rightJoystickInput = rightJoystick.GetInputDirection();
        float horizontal = rightJoystickInput.x;
        float vertical = rightJoystickInput.y;
    
        float angle = Mathf.Atan2(horizontal, vertical) * Mathf.Rad2Deg;
        angle = flipRot ? -angle : angle;
    
        rotationTarget.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
