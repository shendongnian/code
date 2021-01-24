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
    private IEnumerator PlayRandomly()
    {
        while (true)
        {
            clipsList.Shuffle();
            foreach (var randClip in clipsList)
            {
                animator.Play(randClip.name);
                yield return new WaitForSeconds(randClip.length);
            }
        }
    }
