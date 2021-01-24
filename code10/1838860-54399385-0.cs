    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication98
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                Event cEvent = new Event(FILENAME);
            }
        }
        public class Event
        {
            static List<Event> events = new List<Event>();
            private String dataItemId { get; set; }
            private DateTime Timestamp { get; set; }
            private String Name { get; set; }
            //STARTED AUTOMATIC in the xml file
            private String Value { get; set; }
            public Event() { }
            public Event(string filename)
            {
                XDocument doc = XDocument.Load(filename);
                XNamespace ns = doc.Root.GetDefaultNamespace();
                foreach (XElement xEvent in doc.Descendants(ns + "Events"))
                {
                    foreach (XElement element in xEvent.Elements())
                    {
                        Event newEvent = new Event();
                        events.Add(newEvent);
                        newEvent.dataItemId = (string)element.Attribute("dataItemId");
                        newEvent.Timestamp = (DateTime)element.Attribute("timestamp");
                        newEvent.Name = element.Name.LocalName;
                        newEvent.Value = (string)element;
                    }
                }
            }
        }
    }
