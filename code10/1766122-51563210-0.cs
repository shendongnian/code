    IEnumerator co = null;
    
    void Start()
    {
        co = FunA();
        Invoke("OnCancelButtonClick", 1f);
        StartCoroutine(co);
    }
    
    private IEnumerator FunA()
    {
        Debug.Log("Enter FunA...");
        yield return FunB();
        Debug.Log("FunA end...");
    }
    
    private IEnumerator FunB()
    {
        Debug.Log("Enter FunB...");
        yield return RepeatPrint();
        Debug.Log("FunB end...");
    }
    
    private IEnumerator RepeatPrint()
    {
        for (int i = 0; i < 5; i++)
        {
            Debug.Log(i);
            yield return new WaitForSeconds(1);
        }
    }
    
    /// <summary>
    /// Set this function to a button on UI Canvas 
    /// </summary>
    public void OnCancelButtonClick()
    {
        if (co != null)
        {
            StopCoroutine(co);
            Debug.Log("Stop Coroutine...");
            co = null;
        }
    }
