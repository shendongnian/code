    [assembly: Dependency(typeof(BaseUrlOniOs))]
    namespace abcxyz
    {
        public class BaseUrlOniOs : IBaseUrl
        {
            public string Get()
            {
                return NSBundle.MainBundle.BundlePath;
            }
        }
    }
