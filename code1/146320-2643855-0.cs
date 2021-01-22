    namespace AbstractTestExample
    {
        public abstract class AbstractExample
        {
            protected XmlNode propertyValuesXML;
            protected string getProperty(string propertyName)
            {
                XmlNode node = propertyValuesXML.FirstChild.SelectSingleNode(String.Format("property[name='{0}']/value", propertyName));
                return node.InnerText;
            }
        }
        
        public class AbstractInheret : AbstractExample
        {
            public AbstractInheret(string propertyValues){
                
                propertyValuesXML = new XmlDocument();
                propertyValuesXML.Load(new System.IO.StringReader(propertyValues));
            }
            public void runMethod()
            {
                bool addIfContains = (getProperty("AddIfContains") == null || getProperty("AddIfContains") == "True");
                //Do something with boolean
            }
        }
    }
