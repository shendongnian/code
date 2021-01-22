    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    
    namespace XML
    {
        public class Parser
        {
      
            private string _FilePath = string.Empty;
    
            private XDocument _XML_Doc = null;
    
    
            public Parser(string filePath)
            {
                _FilePath = filePath;
                _XML_Doc = XDocument.Load(_FilePath);
            }
    
   
            /// <summary>
            /// Replaces values of all attributes of a given name (attributeName) with the specified new value (newValue) in all elements.
            /// </summary>
            /// <param name="attributeName"></param>
            /// <param name="newValue"></param>
            public void ReplaceAtrribute(string attributeName, string newValue)
            {
                ReplaceAtrribute(string.Empty, attributeName, new List<string> { }, newValue);
            }
    
            /// <summary>
            /// Replaces values of all attributes of a given name (attributeName) with the specified new value (newValue) in elements with a given name (elementName).
            /// </summary>
            /// <param name="elementName"></param>
            /// <param name="attributeName"></param>
            /// <param name="newValue"></param>
            public void ReplaceAtrribute(string elementName, string attributeName, string newValue)
            {
                ReplaceAtrribute(elementName, attributeName, new List<string> { }, newValue);
            }
    
    
            /// <summary>
            /// Replaces values of all attributes of a given name (attributeName) and value (oldValue)  
            /// with the specified new value (newValue) in elements with a given name (elementName).
            /// </summary>
            /// <param name="elementName"></param>
            /// <param name="attributeName"></param>
            /// <param name="oldValue"></param>
            /// <param name="newValue"></param>
            public void ReplaceAtrribute(string elementName, string attributeName, string oldValue, string newValue)
            {
                ReplaceAtrribute(elementName, attributeName, new List<string> { oldValue }, newValue);              
            }
    
    
            /// <summary>
            /// Replaces values of all attributes of a given name (attributeName), which has one of a list of values (oldValues), 
            /// with the specified new value (newValue) in elements with a given name (elementName).
            /// If oldValues is empty then oldValues will be ignored.
            /// </summary>
            /// <param name="elementName"></param>
            /// <param name="attributeName"></param>
            /// <param name="oldValues"></param>
            /// <param name="newValue"></param>
            public void ReplaceAtrribute(string elementName, string attributeName, List<string> oldValues, string newValue)
            {
                List<XElement> elements = _XML_Doc.Elements().Descendants().ToList();
    
                foreach (XElement element in elements)
                {
                    if (elementName == string.Empty | element.Name.LocalName.ToString() == elementName)
                    {
                        if (element.Attribute(attributeName) != null)
                        {
    
                            if (oldValues.Count == 0 || oldValues.Contains(element.Attribute(attributeName).Value))
                            { element.Attribute(attributeName).Value = newValue; }
                        }
                    }
                }
    
            }
    
            public void SaveChangesToFile()
            {
                _XML_Doc.Save(_FilePath);
            }
        }
    }
