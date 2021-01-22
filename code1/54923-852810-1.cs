    // Mutex example
    object mySync = new object();
    Dictionary<int, int> myDict = new Dictionary<int, int>();
    
    void threadMainA()
    {
        lock(mySync)
        {
            mySync[foo] = bar;
        }
    }
    
    void threadMainB()
    {
        lock(mySync)
        {
            mySync[bar] = foo;
        }
    }
            
