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
                XmlData data = new XmlData(FILENAME);
            }
        }
        public class XmlData
        {
            public int? num_threads { get; set;}
            public int? ramp_time { get;set;}
            public string path { get; set;}
            public string domain { get;set;}
            public XmlData(string filename)
            {
                XDocument doc = XDocument.Load(filename);
                XElement threadGroup = doc.Descendants("ThreadGroup").FirstOrDefault();
                num_threads = (int?)threadGroup.Elements("stringProp").Where(x => (string)x.Attribute("name") == "ThreadGroup.num_threads").FirstOrDefault();
                ramp_time = (int?)threadGroup.Elements("stringProp").Where(x => (string)x.Attribute("name") == "ThreadGroup.ramp_time").FirstOrDefault();
                XElement HTTPSamplerProxy = doc.Descendants("HTTPSamplerProxy").FirstOrDefault();
                path = (string)HTTPSamplerProxy.Elements("stringProp").Where(x => (string)x.Attribute("name") == "HTTPSampler.path").FirstOrDefault();
                domain = (string)HTTPSamplerProxy.Elements("stringProp").Where(x => (string)x.Attribute("name") == "HTTPSampler.domain").FirstOrDefault();
            }
        }
    }
