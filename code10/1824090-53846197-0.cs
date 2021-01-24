    using Microsoft.Extensions.DependencyInjection;
    var server = new TestServer(
                    WebHost.CreateDefaultBuilder()
                            .UseStartup<Startup>()
        );
    var testReg = server.Host.Services.GetRequiredService<ITestReg>();
    var test = testReg.HelloWorld();
