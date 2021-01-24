    private bool isRotating;
    
    public void ToggleRotation()
    {
        // if rotating stop the routine otherwise start one
        if(isRotating)
        {
            StopCoroutine(RotateRoutine());
            isRotating = false;
        }
        else
        {
            StartCoroutine(RotateRoutine());
            isRotating = true;
        }
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
