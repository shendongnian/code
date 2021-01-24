        public TestBase(ITestOutputHelper testOutputHelper)
        {
            Container.RegisterInstance(testOutputHelper);
            Container.Register(typeof(ILogger<>), typeof(XunitLogger<>));
        }
