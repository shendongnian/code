    AsyncOperation asyncLoadLevel;
    IEnumerator LoadLevel()
    {
        asyncLoadLevel = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Single);
        while (!asyncLoadLevel.isDone)
        {
            print("Loading the Scene");
            yield return null;
        }
        //the game has finished loading
        ScoreManager.Reset();
        ScoreManager.AddPoints(blueWaffle);
        //player.GetComponent<Transform> ().position = loadedPosition;
        if (loaded(posX, posY, posZ))
        {
            Debug.Log("I changed my position");
        }
        else
        {
            Debug.Log("I didint change my position");
        }
        Time.timeScale = 1f;
    }
