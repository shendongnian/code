    private void DeactivateCloseGoodBads(Vector3 position, float maxDistance)
    {
        // Deactivate close goods
        GameObject[] goodObjects = GameObject.FindGameObjectsWithTag("Good");
        foreach (GameObject goodObject in goodObjects)
        {
            // Check distance of found good
            if (Vector3.Distance(position, goodObject.transform.position) <= maxDistance) {
                goodObject.SetActive(false);
            }
        }
        // Deactivate close bads
        GameObject[] badObjects = GameObject.FindGameObjectsWithTag("Bad");
        foreach (GameObject badObject in badObjects)
        {
            // Check distance of found bad
            if (Vector3.Distance(position, badObject.transform.position) <= maxDistance) {
                badObject.SetActive(false);
            }
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
            DeactivateCloseGoodBads(gameObject.transform.position, 10f);
        }
    
    }
