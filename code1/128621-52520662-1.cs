    static void Main(string[] args)
    {
        string serviceName = args.Single(x => x.StartsWith("-s")).Substring("-s".Length);
        ServiceBase service = new Service(serviceName);
        ServiceBase.Run(service);
    }
