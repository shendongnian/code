    using System.Xml;
    using System.Reflection;
    using System.ComponentModel.DataAnnotations;
    using System.Collections;
    
    namespace MyProject.Helpers
    {
        public class XMLHelper
        {
            public static void HydrateXMLtoObject(object myObject, XmlNode node)
            {
                if (node == null)
                {
                    return;
                }
    
                PropertyInfo propertyInfo;
                IEnumerator list = node.GetEnumerator();
                XmlNode tempNode;
    
                while (list.MoveNext())
                {
                    tempNode = (XmlNode)list.Current;
    
                    propertyInfo = myObject.GetType().GetProperty(tempNode.Name);
    
                    if (propertyInfo != null) {
                        setProperty(myObject,propertyInfo, tempNode.InnerText);
                    
                    }
                }
            }
        }
    }
