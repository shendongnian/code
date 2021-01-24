    void Start()
    {
        StartCoroutine(sequenceCode());
    }
    
    IEnumerator sequenceCode()
    {
        while (!gameOver)
        {
            if (!spawned)
            {
                //Do something
            }
            else if (timer >= 2.0f)
            {
                //Do something else
            }
            else
            {
                timer += Time.deltaTime;
            }
    
            //Wait for a frame to give Unity and other scripts chance to run
            yield return null;
        }
    }
