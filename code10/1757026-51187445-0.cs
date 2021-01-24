    private void Update(){
        this.transform.eulerAngles = CameraController.Instance.camTransform.eulerAngles;
        Vector3 moveVector = InputManager.MainJoystick ();
        moveVector.x = moveVector.x * walkingSpeed;
        moveVector.y = verticalVelocity;
        moveVector.z = moveVector.z * walkingSpeed;
        // new line of code:
        moveVector = Quaternion.Euler(CameraController.Instance.camTransform.eulerAngles) * moveVector;
        controller.Move (moveVector * Time.deltaTime);
    }
