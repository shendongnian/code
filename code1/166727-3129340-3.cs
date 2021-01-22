    class Test
    {
        public event EventHandler SomeEvent;
        public void DoSomething()
        {
            SomeEvent.Raise(this);
        }
    }
