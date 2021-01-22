        public string GetVersion()
        {
            Assembly assy = Assembly.GetCallingAssembly();
            Version v = assy.GetName().Version;
            return v.ToString();
        }
