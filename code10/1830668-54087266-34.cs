    private bool isRotating = false;
    
    private void Update()
    {
        // if not rotating do nothing
        if(!isRotating) return;
        // rotate a bit
        transform.RotateAround(sun.transform.position, Vector3.up, speed * Time.deltaTime);
    }
    public void Rotate()
    {
        // enable the rotation
        isRotating = true;
    }
