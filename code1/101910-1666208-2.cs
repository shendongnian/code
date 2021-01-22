    private static readonly object _syncRoot = new object();
    public static void Save(string file)
    {
        lock(_syncRoot) {
            //1.Perform Delete
            //2.Perform Write 
        }
    }
