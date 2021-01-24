    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<InitModule>();
            var container = builder.Build();
            using (var scope = container.BeginLifetimeScope())
            {
                var a = scope.ResolveNamed<WhateverService>("MyServiceType1");
                var c = scope.Resolve<RandomInnerClass>();
                var e = scope.Resolve<ClassThatWorks>();
                // This one now works
                var f = scope.Resolve<ClassThatDoesNotWork>();
            }
        }
    }
    public class InitModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            RegisterTemplateServices(builder);
            RegisterPropertiesGenerationServices(builder);
        }
        private void RegisterTemplateServices(ContainerBuilder builder)
        {
            builder.RegisterType<WhateverService>()
                .WithParameter(new NamedParameter("myIdentifier", "MyServiceType1"))
                .Named<WhateverService>("MyServiceType1")
                .AsSelf()
                .SingleInstance();
            
            //var myServiceType2 = new WhateverService("MyServiceType2");
            //builder.RegisterInstance(myServiceType2).Keyed<WhateverService>("MyServiceType2").SingleInstance();
        }
        private void RegisterPropertiesGenerationServices(ContainerBuilder builder)
        {
            builder.RegisterType<AnotherClass>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<RandomInnerClass>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<ClassThatWorks>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<ClassThatDoesNotWork>().AsSelf().InstancePerLifetimeScope();
        }
    }
    internal class AnotherClass
    {
        public AnotherClass(RandomInnerClass resolve)
        {
        }
    }
    internal class ClassThatDoesNotWork
    {
        public ClassThatDoesNotWork(AnotherClass a, [KeyFilter("MyServiceType1")] WhateverService b)
        {
        }
    }
    internal class ClassThatWorks
    {
        public ClassThatWorks(AnotherClass a, [KeyFilter("MyServiceType1")] WhateverService b)
        {
        }
    }
    internal class RandomInnerClass
    {
        public RandomInnerClass([KeyFilter("MyServiceType1")] WhateverService a)
        {
        }
    }
    internal class WhateverService
    {
        public WhateverService(string myIdentifier)
        {
        }
    }
