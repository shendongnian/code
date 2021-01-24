    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    namespace ConsoleApplication51
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
     
            static void Main(string[] args)
            {
                XmlReader reader = XmlReader.Create(FILENAME);
                XmlSerializer serializer = new XmlSerializer(typeof(Alignments));
                Alignments alignments = (Alignments)serializer.Deserialize(reader);
     
            }
        }
        public class Alignments
        {
            [XmlElement("Alignment")]
            public Alignment alignment { get; set; }
        }
        public class Alignment
        {
            public long staStart { get; set; }
            [XmlElement("CoordGeom")]
            public List<LandXMLAlignmentsCoordGeom> CoordGeoms { get; set; }
        }
        public class LandXMLAlignmentsCoordGeom
        {
            [XmlElement("Line")]
            public List<LandXMLAlignmentsCoordGeomLine> CoordGeomLines { get; set; }
            [XmlElement("Spiral")]
            public List<LandXMLAlignmentsCoordGeomSpiral> CoordGeomSpiral { get; set; }
            [XmlElement("Curve")]
            public List<LandXMLAlignmentsCoordGeomLine> CoordGeomCurve { get; set; }
        }
        [System.Xml.Serialization.XmlType("Line", IncludeInSchema = true)]
        public class LandXMLAlignmentsCoordGeomLine
        {
            public int length { get; set; }
            public int position { get; set; }
        }
        [System.Xml.Serialization.XmlType("Spiral", IncludeInSchema = true)]
        public class LandXMLAlignmentsCoordGeomSpiral
        {
            public int position { get; set; }
            public int length { get; set; }
            public string radiusStart { get; set; }
            public string radiusEnd { get; set; }
            public string rot { get; set; }
            public string spiType { get; set; }
        }
        [System.Xml.Serialization.XmlType("Curve", IncludeInSchema = true)]
        public class LandXMLAlignmentsCoordGeomCurve
        {
            public int position { get; set; }
            public int length { get; set; }
            public int radiusStart { get; set; }
            public string rot { get; set; }
        }
     
    }
