    using System;
    using System.Configuration;
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.Configuration;
    using Microsoft.Practices.Unity.InterceptionExtension;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                //IUnityContainer container = new UnityContainer(); 
                //container.AddNewExtension<Interception>(); 
                //container.RegisterType<ILogger, Logger>(); 
                //container.Configure<Interception>().SetInterceptorFor<ILogger>(new InterfaceInterceptor()); 
    
                IUnityContainer container = new UnityContainer();
                UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
                section.Containers["ConfigureInterceptorForType"].Configure(container);
    
    
                var logger = container.Resolve<ILogger>(); 
                logger.Write("World."); 
                Console.ReadKey();
            }
        } 
        
        public interface ILogger
        {
            [Test]        
            void Write(string message);
        } 
        
        public class Logger : ILogger
        {
            public void Write(string message)
            {
                Console.Write(message);
            }
        } 
        
        public class TestAttribute : HandlerAttribute
        {
            public override ICallHandler CreateHandler(IUnityContainer container) 
            { 
                return new TestHandler(); 
            }
        } 
        
        public class TestHandler : ICallHandler
        {
            public int Order { get; set; } 
    
            public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
            {
                Console.Write("Hello, "); 
                return getNext()(input, getNext);
            }
        }
    }
