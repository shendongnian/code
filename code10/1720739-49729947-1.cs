    Coroutine waitCoroutine;
    
    void StartGame()
    {
        StartCoroutine(PrintNumbers());
    }
    
    IEnumerator PrintNumbers()
    {
    
        mainText.text = "Rule";
        yield return new WaitForSeconds(3);
        for (int i = 0; i < 10; i++)
        {
            mainText.text = numberArray[i].ToString();
    
            //stop old coroutine
            cancelWait();
    
            //Start new one then return a reference of it
            waitCoroutine = StartCoroutine(WaitForSecondsOrTap(3));
    
            //Wait for this instance of coroutine to finish then continue with the program
            yield return waitCoroutine;
        }
    
    }
    
    public void OddButtonClicked()
    {
        //Save Answer
        cancelWait();
    }
    public void EvenButtonClicked()
    {
        //Save Answer
        cancelWait();
    }
    
    
    IEnumerator WaitForSecondsOrTap(float seconds)
    {
        waitSystem = seconds;
        while (waitSystem > 0.0)
        {
            waitSystem -= Time.deltaTime;
            yield return 0;
        }
    }
    private void cancelWait()
    {
        if (waitCoroutine != null)
            StopCoroutine(waitCoroutine);
    }
