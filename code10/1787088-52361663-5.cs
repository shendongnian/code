    private void Start()
    {
        // It is save to remove a listener also if it wasn't there yet
        // This makes sure you are not listening twice by accident
        MyEvents.SomeEvent -= OnSomeEvent;
        
    
        // Add the listener for that event
       MyEvents.SomeEvent += OnSomeEvent;
    }
    
    private void OnSomeEvent ()
    {
        // Do something if SomeEvent is invoked
    }
