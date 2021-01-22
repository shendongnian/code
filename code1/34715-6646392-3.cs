    public void foo()
    {
        System.Threading.Timer timer = null; 
        timer = new System.Threading.Timer((obj) =>
                        {
                            bar();
                            timer.Dispose();
                        }, 
                    null, 1000, System.Threading.Timeout.Infinite);
    }
    
    public void bar()
    {
        // do stuff
    }
