    public float duration;
    
    private bool isAlreadyRotating;
    
    public void Rotate()
    {
        // if aready rotating do nothing
        if(isAlreadyRotating) return;
        StartCoroutine(RotateRoutine());
    }
    private IEnumerator RotateRoutine()
    {
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
        
        isAlreadyRotating = false;
    }
