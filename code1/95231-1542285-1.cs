    private static MyObject myObject;
    private object lockObj = new object();
    ...
    public static MyObject GetMyObject()
    {
        lock(lockObj)
        {
            if (myObject == null)
            {
                myObject = new MyObject(...);
            }
        }
        return myObject;
    }
