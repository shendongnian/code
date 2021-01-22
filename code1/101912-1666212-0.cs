    private static Object saveLock = new Object();
    
    public static Save(string file)
    {
       lock (saveLock )
       {
         //...
       }
    }
