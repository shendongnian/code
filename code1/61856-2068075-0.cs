    using System;
    using System.Xml;
    using System.Configuration;
    using System.Reflection;
    //...
    
    namespace Glenlough.Generations.SupervisorII
    {
        public class ConfigSettings
        {
    
            private static string NodePath = "//system.serviceModel//client//endpoint";
            private ConfigSettings() { }
    
            public static string GetEndpointAddress()
            {
                return ConfigSettings.loadConfigDocument().SelectSingleNode(NodePath).Attributes["address"].Value;
            }
    
            public static void SaveEndpointAddress(string endpointAddress)
            {
                // load config document for current assembly
                XmlDocument doc = loadConfigDocument();
    
                // retrieve appSettings node
                XmlNode node = doc.SelectSingleNode(NodePath);
    
                if (node == null)
                    throw new InvalidOperationException("Error. Could not find endpoint node in config file.");
    
                try
                {
                    // select the 'add' element that contains the key
                    //XmlElement elem = (XmlElement)node.SelectSingleNode(string.Format("//add[@key='{0}']", key));
                    node.Attributes["address"].Value = endpointAddress;
                   
                    doc.Save(getConfigFilePath());
                }
                catch( Exception e )
                {
                    throw e;
                }
            }
    
            public static XmlDocument loadConfigDocument()
            {
                XmlDocument doc = null;
                try
                {
                    doc = new XmlDocument();
                    doc.Load(getConfigFilePath());
                    return doc;
                }
                catch (System.IO.FileNotFoundException e)
                {
                    throw new Exception("No configuration file found.", e);
                }
            }
    
            private static string getConfigFilePath()
            {
                return Assembly.GetExecutingAssembly().Location + ".config";
            }
        }
    }
