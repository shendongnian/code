    public class Tests
    {
        private IServiceProvider _serviceProvider;
        [SetUp]
        public void Setup()
        {
            var services = new ServiceCollection();
            services.AddSingleton<CustomServiceOne>();
            services.AddSingleton<CustomServiceTwo>();
            services.AddSingleton<CustomServiceThree>();
            services.AddSingleton<ICustomServiceFactory>(provider => 
                new CustomServiceFactory(provider));
            _serviceProvider = services.BuildServiceProvider();
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
    }
