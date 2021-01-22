    const String SomeValue = "TESTCONSTANT";
    static class ConfigurationSettings
    {
        static String SomeProperty
        {
            get
            {
               var result = SomeValue;
               if (ConfigurationManager.AppSettings["SOMEKEY"] != null)
                   result = ConfigurationManager.AppSettings["SOMEKEY"];
               return result;
            }
        }
    }
