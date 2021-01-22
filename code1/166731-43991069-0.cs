    public event EventHandler SomeEvent;
    private void M()
    {
        // raise the event:
        SomeEvent?.Invoke(this, EventArgs.Empty);
    }
