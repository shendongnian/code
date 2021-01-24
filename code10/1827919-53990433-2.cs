    public readonly int defaultLastLevel = 1; // Set as appropriate
    private static bool loaded = false;
    void Start()
    {
        if (!loaded) {
            loaded = true;
            level_index = PlayerPrefs.GetInt("Last_Level", defaultLastLevel);
            SceneManager.LoadScene(level_index);
        }
    }
