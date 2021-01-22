    public void DoSomethingReusably(Action nonReusableCode)
    {
        // reusable code
        nonReusableCode();
        // more reusable code
    }
    
    public void DoALotOfSomething()
    {
        DoSomethingReusably(() => { /* non-reusable code here */ });
        DoSomethingReusably(() => { /* non-reusable code here */ });
        DoSomethingReusably(() => { /* non-reusable code here */ });
    }
