    public String NextLevelName;
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(NextLevelName, LoadSceneMode.Single);
	}
