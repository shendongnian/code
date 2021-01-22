    private static readonly object syncObj = new object();
    private static int counter;
    public static int NextValue()
    {
        lock (syncObj)
        {
            return counter++;
        }
    }
