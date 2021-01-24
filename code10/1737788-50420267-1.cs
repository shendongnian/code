    class Program
    {
        public class DependencyClass { }
        public interface IMyInterface
        {
            void DoSomething();
        }
        public abstract class SuperClass : IMyInterface
        {
            protected DependencyClass _dependency;
            public SuperClass(DependencyClass dependency)
            {
                _dependency = dependency;
            }
            abstract public void DoSomething();
        }
        public class ChildClassCommon : SuperClass
        {
            public ChildClassCommon(DependencyClass dependency) : base(dependency){}
            public override void DoSomething(){}
        }
        public class ChildClassSpecial : SuperClass
        {
            public ChildClassSpecial(DependencyClass dependency) : base(dependency){}
            public override void DoSomething(){}
        }
        public class MyInterfaceFactory
        {
            private IEnumerable<IMyInterface> _myInterfaces;
            public MyInterfaceFactory(IEnumerable<IMyInterface> myInterfaces)
            {
                _myInterfaces = myInterfaces;
            }
            public IMyInterface Generate(string rule)
            {
                IMyInterface myObject;
                if (rule == "a")
                    myObject = _myInterfaces.First(x => x is ChildClassCommon);
                else
                    myObject = _myInterfaces.First(x => x is ChildClassSpecial);
                return myObject;
            }
        }
        // Injection run in this
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<DependencyClass>().AsSelf();
            builder.RegisterType<MyInterfaceFactory>().AsSelf();
            var assembly = Assembly.GetExecutingAssembly();
            builder
                .RegisterAssemblyTypes(assembly)
                .AssignableTo<IMyInterface>()
                .AsImplementedInterfaces();
            var container = builder.Build();
            var factory = container.Resolve<MyInterfaceFactory>();
            IMyInterface myInterface = factory.Generate("a");
            Console.WriteLine(myInterface.GetType());
            Console.ReadKey();
        }
    }
