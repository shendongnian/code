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
                section.SectionInformation.UnprotectSection ();
    
                var services = section.Services;
    
                for (int i = 0; i < services.Count; i++)
                {
                    Console.WriteLine(services[i].Name + " - " + services[i].Value);
                }            
            }
        }
    
        public class ServicesConfig : ConfigurationSection {
            [ConfigurationProperty("", IsRequired = true, IsDefaultCollection = true)]
            [ConfigurationCollection(typeof(ServicesCollection), AddItemName = "setting")]
            public ServicesCollection Services {
                get { return ((ServicesCollection) (this[""])); }
            }
        }
        
        [ConfigurationCollection (typeof (ServicesElement))]
        public class ServicesCollection : ConfigurationElementCollection {
            protected override ConfigurationElement CreateNewElement () {
                return new ServicesElement ();
            }
    
            protected override object GetElementKey (ConfigurationElement element) {
                return ((ServicesElement) (element)).Name;
            }
    
            public ServicesElement this [int index] {
                get {
                    return (ServicesElement) BaseGet (index);
                }
            }
        }
    
        public class ServicesElement : ConfigurationElement {
            [ConfigurationProperty ("name", DefaultValue = "",
                IsKey = true, IsRequired = true)]
            public string Name {
                get {
                    return ((string) (base["name"]));
                }
                set {
                    base["name"] = value;
                }
            }
    
            [ConfigurationProperty ("value", DefaultValue = "",
                IsKey = false, IsRequired = false)]
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
