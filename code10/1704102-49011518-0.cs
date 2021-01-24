    void Update()
    {
        CameraMovementValidation();
        CameraRotationValidation();
        Camerazoom();
        if (Input.GetKey(KeyCode.LeftShift))
        {
            doSlowMotion = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            doSlowMotion = false;
        }
    }
    public void FixedUpdate()
    {
        CameraMovement();
        CameraRotation();
    }
    public void LateUpdate()
    {
        Controller();
    }
    
    private void CameraMovementValidation()
    {
        if (Input.GetKey(KeyCode.W))
        {
            doCameraUpDownMove = true;
            cameraUpDownMoveDirection = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            doCameraUpDownMove = true;
            cameraUpDownMoveDirection = -1;
        }
        else
        {
            doCameraUpDownMove = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            doCameraLeftRightMove = true;
            cameraLeftRightDirection = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            doCameraLeftRightMove = true;
            cameraLeftRightDirection = 1;
        }
        else
        {
            doCameraLeftRightMove = false;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            doCameraForwardBackMove = true;
            cameraForwardBackDirection = 1;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            doCameraForwardBackMove = true;
            cameraForwardBackDirection = -1;
        }
        else
        {
            doCameraForwardBackMove = false;
        }
    }
    private void CameraMovement()
    {
        if (doCameraUpDownMove)
        {
            cameraPosition += transform.rotation * Vector3.up * moveCoefficent * cameraUpDownMoveDirection * camereSlowMotionMoveCoefficient;
        }
        if (doCameraLeftRightMove)
        {
            cameraPosition += transform.rotation * Vector3.right * moveCoefficent * cameraLeftRightDirection * camereSlowMotionMoveCoefficient;
        }
        if (doCameraForwardBackMove)
        {
            cameraPosition += transform.rotation * Vector3.forward * moveCoefficent * cameraForwardBackDirection * camereSlowMotionMoveCoefficient;
        }
    }
    private void CameraRotationValidation()
    {
        if (Input.GetMouseButtonDown(1))
        {
            mouseXUpdateForRotation = Input.mousePosition.x;
            mouseYUpdateForRotation = Input.mousePosition.y;
        }
        if (Input.GetMouseButton(1))
        {
            doCameraRotation = true;
        }
        else
        {
            doCameraRotation = false;
        }
    }
    private void CameraRotation()
    {
        if (doCameraRotation)
        {
            if (Input.mousePosition.x != mouseXUpdateForRotation)
            {
                cameraRotationX += (Input.mousePosition.x - mouseXUpdateForRotation) * rotationFactor;
                mouseXUpdateForRotation = Input.mousePosition.x;
            }
            if (Input.mousePosition.y != mouseYUpdateForRotation)
            {
                cameraRotationY += (Input.mousePosition.y - mouseYUpdateForRotation) * rotationFactor;
                mouseYUpdateForRotation = Input.mousePosition.y;
            }
        }
    }
    private void Camerazoom()
    {
        mouseScrollCoefficient = Input.GetAxis("Mouse ScrollWheel");
        if (mouseScrollCoefficient > 0)
        {
            zoom += mouseScrollCoefficient * -cameraZoomCoefficent;
        }
        else if (mouseScrollCoefficient < 0)
        {
            zoom += mouseScrollCoefficient * -cameraZoomCoefficent;
        }
    }
    private void Controller()
    {
        transform.position = Vector3.Lerp(transform.position, cameraPosition, moveSmoothlyCoefficient);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(-cameraRotationY, cameraRotationX, 0), rotationSmoothlyCoefficient);
        camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, zoom, zoomSmoothlyCoefficient);
        if (doFolowToPlayer && transform.position.x <= cameraPosition.x + 0.5 && transform.position.x > cameraPosition.x - 0.5 &&
            transform.position.y <= cameraPosition.y + 0.5 && transform.position.y > cameraPosition.y - 0.5 &&
            transform.position.z <= cameraPosition.z + 0.5 && transform.position.z > cameraPosition.z - 0.5)
        {
            cameraRotationY = -mainCamera.transform.localEulerAngles.x;
            cameraRotationX = mainCamera.transform.localEulerAngles.y;
            doRotationFolowToPlayer = true;
            doFolowToPlayer = false;
        }
        
        if (doRotationFolowToPlayer && transform.localEulerAngles.x <= -cameraRotationY + 0.5 && transform.localEulerAngles.x > -cameraRotationY - 0.5 &&
            transform.localEulerAngles.y <= cameraRotationX + 0.5 && transform.localEulerAngles.y > cameraRotationX - 0.5)
        {
            doRotationFolowToPlayer = false;
        }
    }   
