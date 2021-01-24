    private void Update(){
        this.transform.eulerAngles = CameraController.Instance.camTransform.eulerAngles;
        //Vector3 moveVector = Quaternion.Euler(this.transform.eulerAngles) * InputManager.MainJoystick ();
        // EDIT
        Vector3 moveVector = InputManager.MainJoystick ();
        moveVector = transform.TransformDirection(moveVector);
        moveVector.x = moveVector.x * walkingSpeed;
        moveVector.y = verticalVelocity;
        moveVector.z = moveVector.z * walkingSpeed;
        controller.Move (moveVector * Time.deltaTime);
    }
