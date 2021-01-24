    private IEnumerator coroutine;
    
    void Start()
    {
        coroutine = PlaySoundWithAnimation();
    }
    public void onButtonClick()
    {
        StopCoroutine(coroutine);
        // you also need to stop audio here
        //...
        StartCoroutine(coroutine);
    }
