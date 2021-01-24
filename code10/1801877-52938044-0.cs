    private void DeactivateAllGoodBads() 
    {
        // Deactivate all goods
        GameObject[] goodObjects = GameObject.FindGameObjectsWithTag("Good");
        foreach (GameObject goodObject in goodObjects)
        {
            goodObject.SetActive(false);
        }
        // Deactivate all bads
        GameObject[] badObjects = GameObject.FindGameObjectsWithTag("Bad");
        foreach (GameObject badObject in badObjects)
        {
            badObject.SetActive(false);
        }
    }
    public void Store()
    {
        bool isGood = gameObject.CompareTag("Good");
        bool isBad = gameObject.CompareTag("Bad");
        if (isGood)
        {
            moralityCounter++;
            Debug.Log(moralityCounter);
        }
        if (isBad)
        {
            moralityCounter--;
            Debug.Log(moralityCounter);
        }
        if (isGood || isBad)
        {
            DeactivateAllGoodBads();
        }  
    }
