    private Coroutine _autoLoopCoroutine;
    public void LoopButton()
    {
        if (lb == 1)
        {
            StopCoroutine(_autoLoopCoroutine);
            tb--;
        }
        else
        {
            _autoLoopCoroutine = StartCoroutine(AutoLoop());
            tb++;
        }
    }
