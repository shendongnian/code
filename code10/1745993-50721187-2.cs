    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<ApplicationDbContext>(o =>
                    o.UseSqlServer("connection string"))
                .BuildServiceProvider();
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            new ExecutionEngine(context).Run();
        }
    }
