    private TestPassingString TestPassingStringDelegate;
    public void InitializeDelegate()
    {
        TestPassingStringDelegate = MyTestPassingString;
        SetCallbackTestPassingString(TestPassingStringDelegate);
    }
