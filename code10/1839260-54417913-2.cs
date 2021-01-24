    public class SomeClass
    {
        private readonly MySettings _settings;
        public SomeClass(IOptions<MySettings> setitngs)
        {
            _settings = setitngs.Value // notice of using a .Value property
        }
    }
