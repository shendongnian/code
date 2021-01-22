    [ThreadStatic]
    private static MyObject myObject;
    ...
    public static MyObject GetMyObject()
    {
        if (myObject == null)
        {
            myObject = new MyObject(...);
        }
        return myObject;
    }
