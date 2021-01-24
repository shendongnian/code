    public static void readdata(string classtype, string msg)
    {
        ///... your stuff
    }
    static void SendType<T>()
    {
        readdata(typeof(T).Name, "");
    }
    static void Main(string[] args)
    {
        SendType<ClassA>();
        SendType<ClassB>();
        SendType<ClassC>();
    }
