        static void Main(string[] args)
        {
            if (args.Contains("-p") || args.Contains("--portable"))
            {
                MakePortable(Properties.Settings.Default);
                MakePortable(Properties.LastUsedSettings.Default);
                MakePortable(Properties.DefaultSettings.Default);
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(args));
        }
        private static void MakePortable(ApplicationSettingsBase settings)
        {
            var portableSettingsProvider = 
                new PortableSettingsProvider(settings.GetType().Name + ".settings");
            settings.Providers.Add(portableSettingsProvider);
            foreach (System.Configuration.SettingsProperty prop in settings.Properties)
                prop.Provider = portableSettingsProvider;
            settings.Reload();
        }
