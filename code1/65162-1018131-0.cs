    static ConfigurationSettings
    {
         static String SomeSetting
         {
            get
            {
               var result = "HARDCODEDVALUE";
               if (ConfigurationManager.AppSettings["SOMEKEY"] != null)
                   result = ConfigurationManager.AppSettings["SOMEKEY"];
               return result;
         }
    }
