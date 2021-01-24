    public void Foo()
    {
        objectWithTheEvent.OnDataReceived += OnOnDataReceived;
    }
    
    private void OnOnDataReceived(byte[] data, int count)
    {
    
    }
