    public float forwardSpeed = 5f;
    public float sideSpeed = 5f;
    
    private void Update()
    {
        Vector3 deltaPosition = transform.forward * forwardSpeed;
        if (Input.touchCount > 0)
        {
            Vector3 touchPosition = Input.GetTouch(0).position;
            if (touchPosition.x > Screen.width * 0.5f)
                deltaPosition += transform.right * sideSpeed;
            else
                deltaPosition -= transform.right * sideSpeed;
        }
        else{
                deltaPosition = sideSpeed;
        }
        transform.position += deltaPosition * Time.deltaTime;
    }
