    private bool isRotating;
    
    private void Update()
    {
        // if not rotating do nothing
        if(!isRottaing) return;
    
        // rotate a bit
        transform.RotateAround(sun.transform.position, Vector3.up, speed * Time.deltaTime);
    }
    
    public void ToggleRotation()
    {
        // toggle the flag
        isRotating = !isRotating;
    }
