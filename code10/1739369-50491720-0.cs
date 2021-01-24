    namespace AutofacTest
    {
        public interface IServiceA { }
        public interface IServiceB { }
    
        public class ServiceA : IServiceA
        {
        }
    
        public class ServiceB : IServiceB
        {
            private readonly IServiceA _serviceA;
    
            public ServiceB (IServiceA serviceA)
            {
                _serviceA = serviceA;
            }
        }
    
        public class MyConsumer
        {
            private readonly IServiceA _serviceA;
            private readonly IServiceB _serviceB;
    
            public MyConsumer(Func<IServiceA> serviceAFactory, Func<IServiceA, IServiceB> serviceBFactory)
            {
                _serviceA = serviceAFactory();
                _serviceB = serviceBFactory(_serviceA);
            }
        }
    }
