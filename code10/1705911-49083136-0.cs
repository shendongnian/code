    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Message Id", typeof(string));
                dt.Columns.Add("Protocol Version", typeof(string));
                dt.Columns.Add("Name Instance URL", typeof(string));
                dt.Columns.Add("Classname", typeof(string));
                dt.Columns.Add("Key Binding", typeof(string));
                dt.Columns.Add("Key Value", typeof(string));
                dt.Columns.Add("Property Name", typeof(string));
                dt.Columns.Add("Value", typeof(string));
                dt.Columns.Add("Display Value", typeof(string));
                
                XDocument doc = XDocument.Load(FILENAME);
                XElement cim = doc.Root;
                XElement message = cim.Element("MESSAGE");
                XElement value = message.Descendants("VALUE.NAMEDINSTANCE").FirstOrDefault();
                XElement instanceName = value.Element("INSTANCENAME");
                XElement instance = value.Element("INSTANCE");
                string messageId = (string)message.Attribute("ID");
                string version = (string)message.Attribute("PROTOCOLVERSION");
                string url = value.GetNamespaceOfPrefix("fo").NamespaceName;
                string classname = (string)instanceName.Attribute("CLASSNAME");
                string binding = (string)instanceName.Element("KEYBINDING").Attribute("NAME");
                string key = (string)instanceName.Descendants("KEYVALUE").FirstOrDefault();
                foreach(XElement property in instance.Elements("PROPERTY"))
                {
                    dt.Rows.Add(new object[] {
                        messageId,
                        version,
                        url,
                        classname,
                        binding,
                        key,
                        (string)property.Attribute("NAME"),
                        (string)property.Element("VALUE"),
                        (string)property.Element("DisplayValue")
                    });
                }
            }
        }
    }
