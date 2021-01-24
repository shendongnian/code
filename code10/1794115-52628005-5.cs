    using System;
    using System.Configuration;
    using System.Diagnostics;
    
    namespace TestCodeApp {
    
        class TestCode {
            static void Main () {
                ExeConfigurationFileMap configMap = new ExeConfigurationFileMap { ExeConfigFilename = "TestCodeApp.exe.config" };
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration (configMap, ConfigurationUserLevel.None);
    
                var section = (ServicesConfig) config.GetSection ("Services");
    
                // This fixes the below error
                // error CS0122: 'System.Configuration.ConfigurationElement.this[System.Configuration.ConfigurationProperty]' is inaccessible due to its protection level
                section.SectionInformation.UnprotectSection();
    
                var services = section.ServicesKeys;
                
                for (int i = 0; i < services.Count; i++)
                {
                    Console.WriteLine(services[i].Key + " - " + services[i].Value);
                }
            }
        }
    
        public class ServicesConfig : ConfigurationSection {
            [ConfigurationProperty ("ServicesKeys")]
            public ServicesCollection ServicesKeys {
                get { return ((ServicesCollection) (base["ServicesKeys"])); }
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
