    public interface IConfig
    {
		void SomeMethod();
	}
    public static class ConfigurationManager
    {
        private static IConfig config;
        private static volatile bool initialized;
        private static readonly object lockObject = new object();
        public static string ConfigFile
        {
            get { return Properties.Settings.Default.ConfigFile; }
            set
            {
                if (Properties.Settings.Default.ConfigFile == value) return;
                lock (lockObject)
                {
                    Properties.Settings.Default.Save();
                    initialized = false;
                }
            }
        }
        public static IConfig Config
        {
            get
            {
                Inititialize();
                return config;
            }
        }
        private static void Inititialize()
        {
            lock (lockObject)
            {
                if (initialized) return;
                config = new Configuration(Properties.Settings.Default.ConfigFile);
                initialized = true;
            }
        }
    }
	
    internal class Configuration : IConfig
    {
        public ClientConfig(string configFile)
        {
			// Parse & validate config file
        }
		
		public void SomeMethod()
		{
		}
	}
