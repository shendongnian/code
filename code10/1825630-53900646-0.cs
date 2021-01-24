    static void Main(string[] args)
    {
        byte[] data = SomeFunctionThatRetrunsTheBytesOfTheExeResource()
        var assembly = Assembly.Load(data);
        assembly.EntryPoint.Invoke(null, null);
    }
