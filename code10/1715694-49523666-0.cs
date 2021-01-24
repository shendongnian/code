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
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ConformanceLevel = ConformanceLevel.Fragment;
                XmlReader reader = XmlReader.Create(FILENAME,settings);
                while (!reader.EOF)
                {
                    if (reader.Name != "element")
                    {
                        reader.ReadToFollowing("element");
                    }
                    if (!reader.EOF)
                    {
                        XElement element = (XElement)XElement.ReadFrom(reader);
                        Element newElement = new Element();
                        Element.elements.Add(newElement);
                        newElement.address = int.Parse(((string)element.Element("adresse")).Substring(2), System.Globalization.NumberStyles.HexNumber);
                        newElement.typ = (string)element.Element("typ");
                        newElement.faktor = (int)element.Element("faktor");
                        newElement.einheit = (string)element.Element("einheit");
                        newElement.kommentar = (string)element.Element("kommentar");
                        newElement.range = (string)element.Element("range");
                        newElement.wert = (int)element.Element("wert");
                    }
                }
            }
        }
        public class Element
        {
            public static List<Element> elements = new List<Element>();
            public int address  { get; set;}
            public string typ  { get; set;}
            public int faktor  { get; set;}
            public string einheit  { get; set;}
            public string kommentar  { get; set;}
            public string range  { get; set;}
            public int wert  { get; set;}
        }
    }
