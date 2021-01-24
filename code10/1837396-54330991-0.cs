    [InvokeMethod(nameof(WaitForSomeElements), TriggerEvents.AfterClick)]
    public Button<_> DoSomething { get; private set; }
    
    private void WaitForSomeElements()
    {
        SomeControl.Wait(Until.Visible);
        AnotherControl.Wait(Until.Visible);
    }
