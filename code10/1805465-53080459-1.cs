    public void SurroundWithInitializeAndCleanup(Action actionToWrap)
    {
        Initialize();
        actionToWrap();
        Cleanup();
    }
    private void Initialize()
    {
        // Initialization code here.
    }
    private void Cleanup()
    {
       // Cleanup code here.
    }
