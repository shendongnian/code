    class DevModeDependencyTest
    {
        static void Main(string[] args)
        {
            DevModeSetting _devMode = new DevModeSetting();
            #if (DEBUG)
                _devMode = DevModeSettingsHandler.GetDevModeSetting("debug");
                ConfigurationManager.AppSettings["webServiceUrl"] = _devMode.WebServiceUrl;
            #endif
            Console.WriteLine(ConfigurationManager.AppSettings["webServiceUrl"]);
            Console.ReadLine();
        }
    }
}
 
