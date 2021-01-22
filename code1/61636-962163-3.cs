    public delegate void SomethingHappenedEventHandler(object sender, EventArgs e);
    // In user control:
    public event SomethingHappenedEventHandler SomethingHappened;
    // Trigger inside a method in user control:
    SomethingHappenedEventHandler eh = SomethingHappened;
    if (eh != null) eh(this, EventArgs.Empty);
    // In page:
    userControl.SomethingHappened = new SomethingHappendEventHandler(OnSomething);
    
    private void OnSomething(object sender, EventArgs e)
    {
        // When something happens on user control, this will be called.
    }
