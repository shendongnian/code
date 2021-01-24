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
            static void Main(string[] args)
            {
                string coordinates = "1537544.53,452064.2 1537541.719999999,452062.3099999999 1537523.159999999,452044.55 1537544.53,452064.2";
                string line = "<gml:LineString  xmlns:gml=\"http://www.opengis.net/gml\"></gml:LineString>";
                XElement xLine = XElement.Parse(line);
                XNamespace ns = xLine.GetNamespaceOfPrefix("gml");
                xLine.Add(new XElement(ns + "coordinates"), coordinates);
            }
        }
    }
