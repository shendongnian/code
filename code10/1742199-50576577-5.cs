    public static void Main(string[] args)
    {
        var host = BuildWebHost(args);
        Migrate(host.Services);
        host.Run();
    }&#xD;&#xD;
