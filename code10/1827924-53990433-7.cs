    public void CompleteLevel()
    {
        Invoke("NextLevel", NextLevelDelay);
        level_index = SceneManager.GetActiveScene().buildIndex + 1; // use this instead
        PlayerPrefs.SetInt("Last_Level", level_index);
        PlayerPrefs.Save();
    }
