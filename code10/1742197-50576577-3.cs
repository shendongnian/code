    public static void Main(string[] args)
    {
        var seed = args.Contains("/seed");
        if (seed)
        {
            args = args.Except(new[] { "/seed" }).ToArray();
        }
        var host = BuildWebHost(args);
        if (seed)
        {
            EnsureSeedData(host.Services);
        }
        host.Run();
    }
