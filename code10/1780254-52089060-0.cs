    public float reachThreshold = 0.2f;
    
    void Start()
    {
        StartCoroutine(MoveBject());
    }
    
    IEnumerator MoveBject()
    {
        float distance = Vector3.Distance(transform.position, new Vector3(desX, desY));
    
        while (distance > reachThreshold)
        {
            // 2 - Movement
            Vector3 movement = new Vector3(
                0.1f * desX,
                0.1f * desY,
                0);
    
            //movement *= Time.deltaTime;
            transform.Translate(movement);
    
            //Wait a frame
            yield return null;
        }
    }
