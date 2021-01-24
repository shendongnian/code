    private static MyClass instance = null;
    public static MyClass Instance
    {
        get {
            if(instance == null){
                GameObject inst = new GameObject("MyClass Singleton");
                instance = inst.AddComponent<MyClass>();
                DontDestroyOnLoad(inst);
            }
            return instance;
        }
    }
