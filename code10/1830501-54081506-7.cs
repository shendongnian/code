    private bool wasInitialized;
    public void Init()
    {
        // Only start the coroutine if not initialized yet
        if (!wasInitialized && clipsList.Count > 0)
        {
            wasInitialized = true;
            StartCoroutine(PlayRandomly());
        }
    }
