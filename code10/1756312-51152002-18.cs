     public interface IService1
        {
            string GetData(int a);
            int ValueForB { get; set; }
        }
    public class Service1Consumer : IService1
    {
        private readonly IAnotherService _anotherServiceImplementation;
        public Service1Consumer(IAnotherService service)
        {
            _anotherServiceImplementation = service;
        }
        public string GetData(int a)
        {
            ValueForB = a * new Random().Next();
            _anotherServiceImplementation.ValueFor = b;
            var processA = new ProcessA(_anotherServiceImplementation);
            return processA.Run();
        }
    }
    public interface IAnotherService
    {
        int ValueForB { get; set; }
    }
    public class AnotherService : IAnotherService
    {
    }
    public class ProcessA
    {
        public string result;
        private readonly IAnotherService _anotherService;
        public ProcessA(IAnotherService anotherService)
        {
            _anotherService = anotherService;
        }
        public string Run()
        {
            return "XXXX";
        }
    }
