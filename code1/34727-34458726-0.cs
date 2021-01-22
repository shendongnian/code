    public void foo()
    {
        Task.Delay(1000).ContinueWith(t=>{
            bar();
        });
    
    }
    
    public void bar()
    {
        // do stuff
    }
