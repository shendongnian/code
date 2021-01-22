    using System;
    using System.Configuration;
    using System.Text;
    namespace CustomConfiguration {
      public class TestConfigData : ConfigurationSection {
        [ConfigurationProperty("Name", IsRequired=true)]
        public string Name {
          get {
            return (string)this["Name"];
          }
          set {
            this["Name"] = value;
          }
        }
        [ConfigurationProperty("Data", IsRequired=false),
         IntegerValidator(MinValue=0)]
        public int Data {
          get {
            return (int)this["Data"];
          }
          set {
            this["Data"] = value;
          }
        }
      }
    }
