    using System.Net;
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    public static void Main(string[] args)
    {
        IWebHost host = new WebHostBuilder()
            .UseKestrel()
            .Configure(app =>
            {
                // notice how we don't have app.UseMvc()?
                app.Map("/hello", SayHello);  // <-- ex: "http://localhost/hello"
            })
            .Build();
        host.Run();
    }
    private static void SayHello(IApplicationBuilder app)
    {
        app.Run(async context =>
        {
            // implement your own response
            await context.Response.WriteAsync("Hello World!");
        });
    }
