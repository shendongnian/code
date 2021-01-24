    public void InstanceCallSite()
    {
        ReadValue("a", "b", "c");
        // or in the general case: someInstance.ReadValue("a", "b", "c");
        Foo.ReadValue("a", "b", "c");
    }
    public static void StaticCallSite()
    {
        ReadValue("a", "b", "c");
    }
    public static string ReadValue(string filePath, string section, string key, string defaultValue = "")
    {
        Console.WriteLine("static");
        return "";
    }
    public string ReadValue(string Section, string Key, string defaultValue = "")
    {
        Console.WriteLine("instance");
        return "";
    }
