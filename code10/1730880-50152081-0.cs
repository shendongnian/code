    static void Main()
    {
        var host = new JobHost(new JobHostConfiguration
        {
            NameResolver = new QueueNameResolver(),
    
        });
        host.RunAndBlock();
    }
