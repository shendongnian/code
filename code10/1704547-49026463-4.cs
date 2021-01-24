    public static void SetMember<T>(ref T local, T newValue, string nameOfLocal)
    {
        local = newValue;
        // nameofLocal can be used ..
    }
    static void Main(string[] args)
    {
        var text = "test";
        SetMember(ref text, "new value", nameof(text));
        Console.Write(text);
    }
