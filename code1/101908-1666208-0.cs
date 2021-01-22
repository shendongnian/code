    private static readonly object _syncRoot = new object();
    public static Save(string file)
    {
        lock(_syncRoot) {
            //1.Perform Delete
            //2.Perform Write 
        }
    }
