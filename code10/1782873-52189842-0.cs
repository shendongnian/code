    [TestFixture(PlatformType.Mainline)]
    [TestFixture(PlatformType.Other)]
    public class MyTestFixture
    {
        private PlatformType _platform;
        public MyTestFixture(PlatformType platform)
        {
            _platform = platform;
        }
        ...
    }
