    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection()
                .AddTransient<IServiceB, ServiceB>()
                .BuildServiceProvider();
            var servB = services.GetService<IServiceB>();
        }
    }
    public interface IServiceA { }
    public interface IServiceB { }
    public class ServiceA : IServiceA { }
    public class ServiceB : IServiceB { public ServiceB(IServiceA a) { } }
