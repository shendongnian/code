    private static MyClass instance = null
    public static MyClass Instance
    {
        get {
            if(instance == null)
                instance = new MyClass();
            return instance;
        }
    }
