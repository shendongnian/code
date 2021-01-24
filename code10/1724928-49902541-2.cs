    public class WebSettingsProvider : ISettingsProvider
    {
        public string GetSettingA()
        {
             // go get the value from cookies
             return Cookies["MyCookie1"];
        }
        public string GetSettingB()
        {
             // go get the value from cookies
             return Cookies["MyCookie2"];
        }
    }
