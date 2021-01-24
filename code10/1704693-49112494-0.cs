    public class Program
    {
        public static void Main()
        {
            new WebHostBuilder()
                .UseKestrel()
                .Configure(app =>
                {
                    app.Run(async context => await context.Response.WriteAsync("Hello World!"));
                })
                .Build()
                .Run();
        }
    }
