    namespace TestExample
    {
        public interface PropertyManager {
          public string getProperty(string propertyName);
        }
        
        public class XmlPropertyManager: PropertyManager {
          public string getProperty(string propertyName) {
          //...xml parsing code here
          }
        }
        
        public class Example {
          private PropertyManager propertyManager;
        
          public void runMethod() {
            bool addIfContains = (propertyManager.getProperty("AddIfContains") == null || propertyManager.getProperty("AddIfContains") == "True");
            //Do something with boolean
          }
        }
    }
