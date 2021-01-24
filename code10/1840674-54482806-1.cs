    // set this in the Inspector
    public float resetDuration;
    // ...
        else 
        {
            StartCoroutine(RotateToIdentity());
        }
   
    // ...
    
    private IEnumerator RotateToIdentity()
    {
        var currentRot = transform.localRotation;
        var targetRot = Quaternion.Identity;
        var timePassed = 0.0f;
        while(timePassed <= resetDuration)
        {
            // interpolate between the original rotation and the target
            // using timePassed / resetDuration as factor => a value between 0 and 1
            transform.localRotation = Quaternion.Lerp(currentRot, targetRot, timePassed / resetDuration);
            // add passed time since last frame
            timePassed += Time.deltaTtime;
            
            // return to the mein thread, render the frame and go on in the next frame
            yield return null;
        }
        
        // finally apply the target roattion just to be sure to avoid over/under shooting
        transform.localRotation = targetRot;
        // if you really want to go on using xRotation, yRotation and zRotation also reset them when done
        xRotation = 0;
        yRotation = 0;
        zRotation = 0;
    }
