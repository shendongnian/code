     using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Configuration;
    
    namespace DevModeDependencyTest
    {
        class DevModeDependencyTest
        {
            static void Main(string[] args)
            {
                DevModeSetting devMode = new DevModeSetting();
    
                #if (DEBUG)
                    devMode = DevModeSettingsHandler.GetDevModeSetting("debug");
                    ConfigurationManager.AppSettings["webServiceUrl"] = devMode.WebServiceUrl;
                #endif
    
                Console.WriteLine(ConfigurationManager.AppSettings["webServiceUrl"]);
                Console.ReadLine();
            }
        }
    }
 
