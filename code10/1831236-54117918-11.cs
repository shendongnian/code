    using RedHat.AspNetCore.Server.Kestrel.Transport.Linux; // <--- note this !
    public static IWebHost BuildWebHost(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseLinuxTransport()     // <--- and note this !!!
            .UseStartup()
            .Build();
    // note: It's safe to call UseLinuxTransport on non-Linux platforms, it will no-op
