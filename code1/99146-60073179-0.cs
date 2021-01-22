    [Conditional("DEBUG")]
    private void IsDebugCheck(ref bool isDebug)
    {
        isDebug = true;
    }
     
    public void SomeCallingMethod()
    { 
        bool isDebug = false;
        IsDebugCheck(ref isDebug);
        //do whatever with isDebug now
    }
