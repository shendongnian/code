    namespace AutofacTest
    {
        public interface IServiceA { }
        public interface IServiceB { }
        public interface IMyConsumer { }
    
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
    
        public class MyConsumer : IMyConsumer
        {
            private readonly IServiceA _serviceA;
            private readonly IServiceB _serviceB;
    
            public MyConsumer(IServiceA serviceA, IServiceB serviceB)
            {
                _serviceA = serviceA;
                _serviceB = serviceB;
            }
        }
       
        public class AutofacInit
        {
            public IContainer BuildContainer()
            {
                var containerBuilder = new ContainerBuilder();
    
                containerBuilder.RegisterType<ServiceA>().AsImplementedInterfaces().InstancePerLifetimeScope();
                containerBuilder.RegisterType<ServiceB>().AsImplementedInterfaces().InstancePerLifetimeScope();
                containerBuilder.RegisterType<MyConsumer>().AsImplementedInterfaces().InstancePerLifetimeScope();
    
                return containerBuilder.Build();
            }
    
            public void Test()
            {
                using (var container = BuildContainer())
                {
                    using (var myConsumer = container.Resolve<Owned<IMyConsumer>>())
                    {
                        //use myConsumer.Value
                    }
                }
            }
        }
    }
