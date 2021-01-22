    static string _myResource = "";
    ...
    public MyClass()
    {
        ...
        lock (_myResource)
        {
        }
    }
