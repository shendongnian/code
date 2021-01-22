    void Test()
    {
        lock (obj)
        {
            obj.AddOne();
            obj.RemoveOne();
        }
    }
    // Inside whatever class "obj" is
    void AddOne()
    {
        lock (this)
        {
            // Do something
        }
    }
