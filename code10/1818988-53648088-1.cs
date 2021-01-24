    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    
    public class Program
    {
    	public static void Main()
    	{
            // Alternatively, use XDocument.Load to load from a file
            string xml = File.ReadAllText("test.xml");
            var doc = XDocument.Parse(xml);
            XNamespace ns = "http://www.hp.com/PC/REST/API";
            var ids = doc.Root
                .Elements(ns + "RunResult")
                .Where(rr => ((string) rr.Element(ns + "Name"))?.StartsWith("HighLevelReport") ?? false)
                .Select(rr => (string) rr.Element(ns + "RunID"));
            foreach (var id in ids)
            {
                Console.WriteLine(id);
            }
    	}
    }
