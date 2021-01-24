    private bool isRotating;
    
    private void Update()
    {
        if(!isRottaing) return;
    
        transform.RotateAround(sun.transform.position, Vector3.up, speed * Time.deltaTime);
    }
    
    public void ToggleRotation()
    {
        // toggle the flag
        isRotating = !isRotating;
    }
