    private static object locker = new Object();
    
    //..
    
    public static void M1()
    {
        lock(locker)
        {
            //..method body here
        }
    }
    
    public static void M2()
    {
        lock(locker)
        {
            //..method body here
        }
    }
