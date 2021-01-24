    public void foo()
    {
        Task.Delay(1000).ContinueWith(t=> bar());
    }
    
    public void bar()
    {
        // do stuff like check that the FileStream position has moved and change the console text
    }
