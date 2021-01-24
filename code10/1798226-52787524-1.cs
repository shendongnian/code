    public static void Main(string[] args)
    {
        BuildWebHost(args)
            .CheckDatabase()
            .Run();
    }
