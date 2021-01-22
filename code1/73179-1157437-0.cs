    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    namespace ChangeAppConfig
    {
        class Program
        {
            static void Main(string[] args)
            {
                MyConfigSetting.CustomerName = "MyCustomer";
                MyConfigSetting.EmailAddress = "MyCustomer@Company.com";
                MyConfigSetting.TimeStamp = DateTime.Now;
                MyConfigSetting.Save();
            }
        }
    
        //Note: This is a proof-of-concept sample and 
        //should not be used in production as it is.  
        // For example, this is not thread-safe. 
        public class MyConfigSetting
        {
            private static string _CustomerName;
            public static string CustomerName
            {
                get { return _CustomerName; }
                set
                {
                    _CustomerName = value;
                }
            }
    
            private static string _EmailAddress;
            public static string EmailAddress
            {
                get { return _EmailAddress; }
                set
                {
                    _EmailAddress = value;
                }
            }
    
            private static DateTime _TimeStamp;
            public static DateTime TimeStamp
            {
                get { return _TimeStamp; }
                set
                {
                    _TimeStamp = value;
                }
            }
            
            public static void Save()
            {
                XElement myAppConfigFile = XElement.Load(Utility.GetConfigFileName());
                var mySetting = (from p in myAppConfigFile.Elements("MySettings")
                                select p).FirstOrDefault();
                mySetting.Attribute("CustomerName").Value = CustomerName;
                mySetting.Attribute("EmailAddress").Value = EmailAddress;
                mySetting.Attribute("TimeStamp").Value = TimeStamp.ToString();
    
                myAppConfigFile.Save(Utility.GetConfigFileName());
                
            }
        }
    
        class Utility
        {        
            //Note: This is a proof-of-concept and very naive code. 
            //Shouldn't be used in production as it is. 
            //For example, no null reference checking, no file existence checking and etc. 
            public static string GetConfigFileName()
            {            
                const string STR_Vshostexe = ".vshost.exe";
                string appName = Environment.GetCommandLineArgs()[0];
    
                //In case this is running under debugger. 
                if (appName.EndsWith(STR_Vshostexe))
                {
                    appName = appName.Remove(appName.LastIndexOf(STR_Vshostexe), STR_Vshostexe.Length) + ".exe";
                }
    
                return appName + ".config";
            }
        }
    }
