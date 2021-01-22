    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Text;
    using RanchBuddy.Core.Services.Impl;
    using StructureMap;
    
    namespace RanchBuddy.Core.Services.Impl
    {
        [Pluggable("Default")]
        public class ConfigurationService : IConfigurationService
        {
            internal static int GetDefaultCacheDuration_Days()
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["DefaultCacheDuration_Days"]);
            }
            
    		...
    
            internal static LoggingType GetLoggingType()
            {
                string loggingType = ConfigurationManager.AppSettings["LoggingType"].ToString();
                if(loggingType.ToLower() == "verbose")
                {
                    return LoggingType.Verbose;
                }
                else if (loggingType.ToLower() == "error")
                {
                    return LoggingType.Error;
                }
                return LoggingType.Error;
            }
    
    		...
    
            public static string GetRoot()
            {
                string result = "";
                if(ConfigurationManager.AppSettings["Root"] != null)
                {
                    result = ConfigurationManager.AppSettings["Root"].ToString();
                }
                return result;
            }
        }
    }
