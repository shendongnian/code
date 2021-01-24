    public class MyClass
    {
        private readonly ILogger<MyClass> _logger;
        public MyClass(ILogger<MyClass> logger)
        {
            _logger = logger;
        }
        public void MyFunc()
        {
            _logger.Log(LogLevel.Error, "My Message");
        }
    }
   
    public class Program
    {
        public static void Main(string[] args)
        {
            var services = new ServiceCollection().AddLogging(logging => logging.AddConsole());
            services.AddSingleton<MyClass>();//Singleton or transient?!
            var s = services.BuildServiceProvider();
            var myclass = s.GetService<MyClass>();
         }
    }
