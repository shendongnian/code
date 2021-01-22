    using System;
    using Microsoft.Practices.ObjectBuilder2;
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.ObjectBuilder;
    
    namespace UnityInterceptors
    {
        class Program
        {
            public class MyInterception : UnityContainerExtension
            {
                protected override void Initialize()
                {
                    Context.Strategies.AddNew<MyInterceptionStrategy>(UnityBuildStage.Setup);
                }
            }
            public class MyInterceptionStrategy : BuilderStrategy
            {
                public override void PostBuildUp(IBuilderContext context)
                {
                    if (!context.OriginalBuildKey.Type.IsInterface)
                    {
                        return;
                    }
    
                    context.Existing = new Foo2();
                }
            }
    
            public class Bar
            {
                public Bar(IFoo f1, IFoo f2, IFoo f3)
                {
                    Console.WriteLine(f1.GetType().Name);
                    Console.WriteLine(f2.GetType().Name);
                    Console.WriteLine(f3.GetType().Name);
                }
            }
    
            public interface IFoo
            {
            }
    
            public class Foo1 : IFoo
            {
            }
    
            public class Foo2 : IFoo
            {
            }
    
            public static void Main()
            {
                UnityContainer container = new UnityContainer();
                container.AddNewExtension<MyInterception>();
                container.RegisterType(typeof(IFoo), typeof(Foo1), new PerResolveLifetimeManager());
    
                container.Resolve<Bar>();
    
                Console.ReadLine();
            }
        }
    }
