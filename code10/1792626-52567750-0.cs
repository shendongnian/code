    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Process process = new Process();
                XDocument doc = new XDocument("root");
                XElement xProcess = SerializeToXml<Process>.Serialize(process);
                doc.Add(xProcess);
            }
     
        }
        
        public class SerializeToXml <T>
        {
            public static XElement Serialize(T data)
            {
                StringWriter writer = new StringWriter();
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                XmlWriter xWriter = XmlWriter.Create(writer, settings);
                
                XmlSerializer serializer = new XmlSerializer(data.GetType());
                
                serializer.Serialize(xWriter, data);
                XmlReader reader = XmlReader.Create(xWriter.ToString());
                writer.Close();
                return (XElement)XElement.ReadFrom(reader);
            } 
        }
        public class Process
        {
            public List<Window> windows { get; set; }
        }
        public class Window
        {
            public List<Control> controls { get; set; }
        }
        public class Control
        {
        }
    }
