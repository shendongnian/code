    private bool isRotating;
    
    public void ToggleRotation()
    {
        if(isRotating)
        {
            StopCoroutine(RotateRoutine());
        }
        else
        {
            StartCoroutine(RotateRoutine());
        }
    }
    
    private IEnumerator RotateRoutine()
    {
        // whuut?!
        // Don't worry coroutines work a bit different
        // the yield return handles that .. never forget it though ;)
        while(true)
        {
            transform.RotateAround(sun.transform.position, Vector3.up, speed * Time.deltaTime);
            yield return null;
        }
    }
