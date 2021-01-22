    /* Usage
     * using(AppConfig.Change("my.config")) {
     *   // do something...
     * }
     */
    public abstract class AppConfig : IDisposable
    {
        public static AppConfig Change(string path)
        {
            return new ChangeAppConfig(path);
        }
        public abstract void Dispose();
        private class ChangeAppConfig : AppConfig
        {
            private bool disposedValue = false;
            private string oldConfig = Conversions.ToString(AppDomain.CurrentDomain.GetData("APP_CONFIG_FILE"));
    
            public ChangeAppConfig(string path)
            {
                AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", path);
                typeof(ConfigurationManager).GetField("s_initState", BindingFlags.NonPublic | BindingFlags.Static).SetValue(null, 0);
            }
    
            public override void Dispose()
            {
                if (!this.disposedValue)
                {
                    AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", this.oldConfig);
                    this.disposedValue = true;
                }
                GC.SuppressFinalize(this);
            }
        }
    }
