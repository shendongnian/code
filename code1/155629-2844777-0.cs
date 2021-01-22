    private object locker = new object();
    
    private void Update()
    {
        lock (locker)
        {
            _usingMethod1 = true;
            SomeProperty = FooMethod();
            //..
            _usingMethod1 = false;
        }
    }
