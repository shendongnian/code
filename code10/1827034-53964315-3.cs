    public class Tests
    {
        private IServiceProvider _serviceProvider;
        [SetUp]
        public void Setup()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IRegisteredWithServiceCollection, RegisteredWithServiceCollection>();
            var container = new WindsorContainer();
            container.Install(new WindsorConfiguration());
            _serviceProvider = WindsorRegistrationHelper.CreateServiceProvider(container, services);
        }
        [TestCase("TypeOne", typeof(CustomServiceOne))]
        [TestCase("TypeTwo", typeof(CustomServiceTwo))]
        [TestCase("TYPEThree", typeof(CustomServiceThree))]
        [TestCase("unknown", typeof(CustomServiceOne))]
        public void FactoryReturnsExpectedService(string input, Type expectedType)
        {
            var factory = _serviceProvider.GetService<ICustomServiceFactory>();
            var service = factory.Create(input);
            Assert.IsInstanceOf(expectedType, service);
        }
        [Test]
        public void ServiceProviderReturnsServiceRegisteredWithServiceCollection()
        {
            var service = _serviceProvider.GetService<IRegisteredWithServiceCollection>();
            Assert.IsInstanceOf<RegisteredWithServiceCollection>(service);
        }
    }
