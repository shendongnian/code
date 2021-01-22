    [TestFixture]
    public class PPTests {
        public interface IFoo {
            void Do();
        }
        public class Foo : IFoo {
            public void Do() {}
        }
        public class MyInterceptor : IInterceptor {
            public void Intercept(IInvocation invocation) {
                Console.WriteLine("intercepted");
            }
        }
        [Test]
        public void Interceptor() {
            var container = new WindsorContainer();
            container.Register(
                Component.For<MyInterceptor>().LifeStyle.Transient,
                AllTypes.Pick()
                    .From(typeof (Foo))
                    .If(t => typeof (IFoo).IsAssignableFrom(t))
                    .Configure(c => c.LifeStyle.Is(LifestyleType.Transient)
                                        .Interceptors(new InterceptorReference(typeof (MyInterceptor))).Anywhere)
                    .WithService.Select(new[] {typeof(IFoo)}));
            container.Resolve<IFoo>().Do();
        }
    }
