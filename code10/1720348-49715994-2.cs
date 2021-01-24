    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XElement resource = doc.Root;
                Dictionary<string, XElement> dict = resource.Elements()
                    .GroupBy(x => (string)x.Attribute("name"), y => y)
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
                if(dict.ContainsKey("app_name"))
                {
                    dict["app_name"].SetValue("Automation Test");
                }
                if (dict.ContainsKey("current_data_state_incoming_call"))
                {
                    dict["current_data_state_incoming_call"].SetValue("مكالمات قادمة");
                }
     
            }
        }
    }
