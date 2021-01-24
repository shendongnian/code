    //new:
    public float Sensitivity;
    
    private Vector3 _lastPosition;
    private void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _lastPosition = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            var delta = (_lastPosition - Input.mousePosition);
            var deltaxz = new Vector3(delta.x, 0f, delta.y);
            //new:
            transform.position = Vector3.Lerp(transform.position, transform.position + deltaxz, Sensitivity * Time.deltaTime);
            _lastPosition = Input.mousePosition;
        }
    }
