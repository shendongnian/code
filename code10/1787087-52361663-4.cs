    public static class MyEvents 
    {
        public static event Action SomeEvent;
    
        public static void InvokeSomeEvent()
        {
             // Make sure event is only invoked if someone is listening
             if (SomeEvent == null) return;
    
            SomeEvent.Invoke();
        }
    }
