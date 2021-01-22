    public static T Test<T>()
    {
        return TestWith(default(T));
        // do something else
    }
    
    public static string TestWith(string dummy)
    {
        // Used only for `string`.
        return "1241";
    }
    
    public static T TestWith<T>(T dummy) {
        // Used for everything else.
    }
