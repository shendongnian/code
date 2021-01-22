    [TestFixture]
    public class WhenRegisteringItemsInTheIoc
    {   
        [SetUp]
        public void Setup()
        {
            Given_A_Ioc_Container();
            When_Registering_Items_In_The_Ioc();
        }
        private Container _container;
        private void Given_A_Ioc_Container()
        {
            _container = new Container();
        }
        public void When_Registering_Items_In_The_Ioc()
        {
            _container.Configure(registry => registry.For<IContext>().HybridHttpOrThreadLocalScoped().Use<Context>());
        }
        [Test]
        public void Then_Should_Have_A_LifeTime_Of_Hybrid_Http_Or_Thread_Local_Scoped()
        {
            IPluginTypeConfiguration plugin =
                _container.Model.PluginTypes.First(p => p.PluginType.UnderlyingSystemType == typeof (IContext));
            Assert.That(plugin.Lifecycle, Is.EqualTo("Hybrid"));
        }
    }
