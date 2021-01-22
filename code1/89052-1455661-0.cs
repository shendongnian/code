        public interface IProcessor { }
    public class ProcessorA : IProcessor { }
    public class ProcessorB : IProcessor { }
    public class ProcessorC : IProcessor { }
    public class ProcessorGroup
    {
        public IProcessor[] Processors { get; private set; }
        public ProcessorGroup(IProcessor[] processors)
        {
            Processors = processors;
        }
    }
    public class ProcessorRegistry : Registry
    {
        public ProcessorRegistry()
        {
            CreateProfile("a", profile =>
            {
                profile.For<ProcessorGroup>().UseNamedInstance("a");
            });
            CreateProfile("b", profile =>
            {
                profile.For<ProcessorGroup>().UseNamedInstance("b");
            });
            ForConcreteType<ProcessorGroup>()
                .Configure.WithName("a")
                .TheArrayOf<IProcessor>().Contains(a =>
                {
                    a.OfConcreteType<ProcessorA>();
                });
            ForConcreteType<ProcessorGroup>()
                .Configure.WithName("b")
                .TheArrayOf<IProcessor>().Contains(a =>
                {
                    a.OfConcreteType<ProcessorB>();
                    a.OfConcreteType<ProcessorC>();
                });
        }
    }
    [TestFixture]
    public class test
    {
        [Test]
        public void processor_group_a()
        {
            var container = new Container(new ProcessorRegistry());
            container.SetDefaultsToProfile("a");
            var processorGroup = container.GetInstance<ProcessorGroup>();
            processorGroup.Processors.Length.ShouldEqual(1);
        }   
        [Test]
        public void processor_group_b()
        {
            var container = new Container(new ProcessorRegistry());
            container.SetDefaultsToProfile("b");
            var processorGroup = container.GetInstance<ProcessorGroup>();
            processorGroup.Processors.Length.ShouldEqual(2);
        }   
    }
