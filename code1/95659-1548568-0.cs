    class ThreadState
    {
        public ThreadState()
        {
        }
    
        public string Name
        {
            get;
            set;
        }
    
        public int Age
        {
            get;
            set;
        }
    }
    
    // ...
    
    ParameterizedThreadStart start = delegate(object objThreadState)
    {
        // cast to your actual object type
        ThreadState state = (ThreadState)objThreadState;
    
        // ... now do anything you want with it ...
    };
