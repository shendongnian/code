    object syncRoot = new object();
    
    void doThis()
    {
        lock(syncRoot ){ ... }
    }
    
    void doThat()
    {
        lock(syncRoot ){ ... }
    }
