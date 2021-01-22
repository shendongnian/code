        public interface ISleepService
        {
            void Sleep(int interval);
        }
        [Test]
        public void Test()
        {
            const int Interval = 1000;
            Mock<ISleepService> sleepService = new Mock<ISleepService>();
            sleepService.Setup(s => s.Sleep(It.IsAny<int>()));
            _container.RegisterInstance(sleepService.Object);
            SomeClass someClass = _container.Resolve<SomeClass>();
            someClass.DoSomething(interval: Interval);
            //Do some asserting.
            //Optionally assert that sleep service was called
            sleepService.Verify(s => s.Sleep(Interval));
        }
        private class SomeClass
        {
            private readonly ISleepService _sleepService;
            public SomeClass(IUnityContainer container)
            {
                _sleepService = container.Resolve<ISleepService>();
            }
            public void DoSomething(int interval)
            {
                while (true)
                {
                    _sleepService.Sleep(interval);
                    break;
                }
            }
        }
