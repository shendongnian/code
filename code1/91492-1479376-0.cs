    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;
    using System.Xml;
    
    namespace SimpleTestConsole
    {
        class Program
        {
            static void Main(string[] args)
            {
                string xmlFile = 
    
                @"<SiteMap>  <Sections><Section Folder=""TradeVolumes"" TabIndex=""1"" />    <Section Folder=""TradeBreaks"" TabIndex=""2"" />  </Sections></SiteMap>";
                XmlDocument currentDocument = new XmlDocument();
                try
                {
                    currentDocument.LoadXml(xmlFile);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                string path = "SiteMap/Sections";
                XmlNodeList nodeList = currentDocument.SelectNodes(path);
                IDictionary<string, string> keyValuePairList = new Dictionary<string, string>();
                foreach (XmlNode node in nodeList)
                {
                    foreach (XmlNode innerNode in node.ChildNodes)
                    {
                        if (innerNode.Attributes != null && innerNode.Attributes.Count == 2)
                        {
                            keyValuePairList.Add(new KeyValuePair<string, string>(innerNode.Attributes[0].Value, innerNode.Attributes[1].Value));
                        }
                    }
                }
                foreach (KeyValuePair<string, string> pair in keyValuePairList)
                {
                    Console.WriteLine(string.Format("{0} : {1}", pair.Key, pair.Value));
                }
                Console.ReadLine();
    
    
            }
        }
    }
