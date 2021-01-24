    using System;
    using System.Configuration;
    using System.Diagnostics;
    
    namespace TestCodeApp {
    
        class TestCode {
            static void Main () {
                ExeConfigurationFileMap configMap = new ExeConfigurationFileMap { ExeConfigFilename = "TestCodeApp.exe.config" };
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration (configMap, ConfigurationUserLevel.None);
    
                var section = (ServicesConfig) config.GetSection ("Services");   
                section.Print();
            }
        }
    
        public class ServicesConfig : ConfigurationSection {
            [ConfigurationProperty ("ServicesKeys")]
            public ServicesCollection ServicesKeys {
                get { return ((ServicesCollection) (base["ServicesKeys"])); }
            }
    
            public void Print()
            {            
                var keys = ((ServicesCollection) (base["ServicesKeys"]));
                
                for (int i = 0; i < keys.Count; i++)
                {
                    Console.WriteLine(keys[i].Key + " - " + keys[i].Value);
                }
            }
        }
    
        [ConfigurationCollection (typeof (ServicesElement))]
        public class ServicesCollection : ConfigurationElementCollection {
            protected override ConfigurationElement CreateNewElement () {
                return new ServicesElement ();
            }
    
            protected override object GetElementKey (ConfigurationElement element) {
                return ((ServicesElement) (element)).Key;
            }
    
            public ServicesElement this [int index] {
                get {
                    return (ServicesElement) BaseGet (index);
                }
            }
        }
    
        public class ServicesElement : ConfigurationElement {
            [ConfigurationProperty ("key", DefaultValue = "",
                IsKey = true, IsRequired = true)]
            public string Key {
                get {
                    return ((string) (base["key"]));
                }
                set {
                    base["key"] = value;
                }
            }
    
            [ConfigurationProperty ("value",
                DefaultValue = "", IsKey = false, IsRequired = false)]
            public string Value {
                get {
                    return ((string) (base["value"]));
                }
                set {
                    base["value"] = value;
                }
            }
        }
    }
