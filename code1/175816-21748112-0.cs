    public partial class App : Application {
        private void startup(object sender, StartupEventArgs e) {
            if (null != e) {
                if (null != e.Args && 0 < e.Args.Length) {
                    string config = e.Args.Where(a => a.StartsWith("config=")).FirstOrDefault();
                    if (null != config) {
                        config = config.Substring("config=".Length);
                        if (File.Exists(config)) {
                            AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", config);
                        }
                    }
                }
            }
        }
