    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication91
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                RootCell rootCell = new RootCell() {
                    cells = new List<Cell>() {
                        new Cell() { cellName = "123"},
                        new Cell() { cellName = "456"}
                    }
                };
                rootCell.Serialize(FILENAME, rootCell);
                RootCell readCells = rootCell.Deserialize(FILENAME);
            }
        }
        public class RootCell
        {
            [XmlElement("cells")]
            public List<Cell> cells { get; set; }
            public void Serialize(string filename, RootCell cells)
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                XmlWriter writer = XmlWriter.Create(filename, settings);
                XmlSerializer serializer = new XmlSerializer(typeof(RootCell));
                serializer.Serialize(writer, cells);
                writer.Flush();
                writer.Close();
            }
            public  RootCell Deserialize(string filename)
            {
                XmlReader reader = XmlReader.Create(filename);
                XmlSerializer serializer = new XmlSerializer(typeof(RootCell));
                return (RootCell)serializer.Deserialize(reader);
            }
        }
        public class Cell
        {
            public string cellName { get; set; }
            public double cellAh { get; set; }
            public double cellNominalVoltage { get; set; }
            public double cellInternalResistance { get; set; }
            public double cylDeg05C25D { get; set; }
            public double cylDeg10C25D { get; set; }
            public double cylDeg20C25D { get; set; }
            public double cylDeg05C35D { get; set; }
            public double cylDeg10C35D { get; set; }
            public double cylDeg20C35D { get; set; }
            public double cylDeg05C45D { get; set; }
            public double cylDeg10C45D { get; set; }
            public double cylDeg20C45D { get; set; }
            public double calDeg1stY25D { get; set; }
            public double calDeg2ndY25D { get; set; }
            public double calDeg3rdY25D { get; set; }
            public double calDeg1stY35D { get; set; }
            public double calDeg2ndY35D { get; set; }
            public double calDeg3rdY35D { get; set; }
            public double calDeg1stY45D { get; set; }
            public double calDeg2ndY45D { get; set; }
            public double calDeg3rdY45D { get; set; }
        }
    }
