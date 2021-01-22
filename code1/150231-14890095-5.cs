    using System.Configuration;
    namespace My {
    public class MyConfigSection : ConfigurationSection {
        [ConfigurationProperty("", IsRequired = true, IsDefaultCollection = true)]
        public MyConfigInstanceCollection Instances {
            get { return (MyConfigInstanceCollection)this[""]; }
            set { this[""] = value; }
        }
    }
    public class MyConfigInstanceCollection : ConfigurationElementCollection {
        protected override ConfigurationElement CreateNewElement() {
            return new MyConfigInstanceElement();
        }
    
        protected override object GetElementKey(ConfigurationElement element) {
            //set to whatever Element Property you want to use for a key
            return ((MyConfigInstanceElement)element).Name;
        }
    }
    
    public class MyConfigInstanceElement : ConfigurationElement {
        //Make sure to set IsKey=true for property exposed as the GetElementKey above
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name {
            get { return (string) base["name"]; }
            set { base["name"] = value; }
        }
    
        [ConfigurationProperty("code", IsRequired = true)]
        public string Code {
            get { return (string) base["code"]; }
            set { base["code"] = value; }
        } } }
