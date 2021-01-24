    private bool isRotating;
    public void Rotate()
    {
        // if aready rotating do nothing
        if(isRotating) return;
        // start the rotation
        StartCoroutine(RotateRoutine());
        isRotating = true;
    }
    private IEnumerator RotateRoutine()
    {
        // whuut?!
        // Don't worry coroutines work a bit different
        // the yield return handles that .. never forget it though ;)
        while(true)
        {
             // rotate a bit
             transform.RotateAround(sun.transform.position, Vector3.up, speed * Time.deltaTime);
            // leave here, render the frame and continue in the next frame
            yield return null;
        }
    }
    
