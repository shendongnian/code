    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication51
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.dcm";
            
            static void Main(string[] args)
            {
               new DataElement(FILENAME);
            }
        }
        public class DataElement
        {
            public static List<DataElement> elements = null;
            
            public UInt16 groupNumber { get; set; }
            public UInt16 elementNumber { get; set; }
            public string vr { get; set; }
            public byte[] reserved { get; set; }
            public uint length { get; set; }
            public byte[] values { get; set; }
            public DataElement() { }
            public DataElement(string filename)
            {
                Stream stream = File.OpenRead(filename);
                BinaryReader bReader = new BinaryReader(stream);
                long length = stream.Length;
                while (stream.Position < length)
                {
                    DataElement element = new DataElement();
                    elements.Add(element);
                    element.groupNumber = bReader.ReadUInt16();
                    element.elementNumber = bReader.ReadUInt16();
                    element.vr = bReader.ReadChars(2).ToString();
                    element.reserved = bReader.ReadBytes(2);
                    element.length = bReader.ReadUInt32();
                    element.values = bReader.ReadBytes((int)element.length);
                }
            }
        }
     
     
    }
