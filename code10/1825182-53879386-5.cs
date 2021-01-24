    public class MyController
    {
        public MyController(ClassA classA)
        { ... }
    }
    public class ClassA
    {
        public ClassA(ClassB classB)
        { ... }
    }
    public class ClassB
    {
        private readonly ILogger _logger;
        public ClassB(ILogger<ClassB> logger)
        {
            _logger = logger;
        }
        public void DoSomethingWithLogging()
        {
            // use _logger
        }
    }
