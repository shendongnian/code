     class Class1
        {
            static Timer timer = new Timer(DoSomething,null,TimeSpan.FromMinutes(1),TimeSpan.FromMinutes(1));
    
            private static void DoSomething(object state)
            {
                timer = null; // stop timer
    
                // do some long stuff here
    
                timer = new Timer(DoSomething, null, TimeSpan.FromMinutes(1), TimeSpan.FromMinutes(1));
            }
    
            
    
        }
