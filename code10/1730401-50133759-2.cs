    private Coroutine loopCoroutine;
    public void LoopButton()
    {
        if (lb == 1)
        {
            StopCoroutine(loopCoroutine);
            tb--;
        }
        else
        {
            loopCoroutine = StartCoroutine(AutoLoop());
            tb++;
        }
    }
