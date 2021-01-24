    // adjust in the inspector
    // how long should rotation carry on (in seconds)?
    public float duration = 1;
    
    private bool isAlreadyRotating;
    
    public void Rotate()
    {
        // if aready rotating do nothing
        if(isAlreadyRotating) return;
        // start a rottaion
        StartCoroutine(RotateRoutine());
    }
    private IEnumerator RotateRoutine()
    {
        // set the flag to prevent multiple callse
        isAlreadyRotating = true;
        float timePassed = 0.0f;
        while(timePassed < duration)
        {
             // rotate a small amount
             transform.RotateAround(sun.transform.position, Vector3.up, speed * Time.deltaTime);
             // add the time passed since last frame
             timePassed += Time.deltaTime;
             // leave here,  render the frame and continue in the next frame
             yield return null;
        }
        
        // reset the flag so another rotation might be started again
        isAlreadyRotating = false;
    }
