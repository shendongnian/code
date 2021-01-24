    [assembly: Dependency(typeof(BaseUrlAndroid))]
    namespace abcxyz
    {
        public class BaseUrlAndroid : IBaseUrl
        {
            public string Get() => "file:///android_asset/";
        }
    }
