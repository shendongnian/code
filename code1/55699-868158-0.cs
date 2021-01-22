    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    
    namespace Serialize
    {
        class Program
        {
            static void Main( string[] args )
            {
                var envelope = new CdsXmlEnvelope
                {
                    TestValue1 = "x1",
                    InnerList = new List<CdsXmlInfo>
                    {
                        new CdsXmlInfo {TestValue1 = "e1"},
                        new CdsXmlInfo {TestValue1 = "e1"},
                        new CdsXmlInfo {TestValue1 = "e1"},
                    }
                };
    
                var ns = new XmlSerializerNamespaces();
                ns.Add( string.Empty, string.Empty );
    
                var serializer = new XmlSerializer( typeof( CdsXmlEnvelope ) );
                using( var stream = new MemoryStream() )
                {
                    var settings = new XmlWriterSettings();
                    settings.OmitXmlDeclaration = true;
                    settings.Indent = true;
    
                    var writer = XmlWriter.Create( stream, settings );
                    serializer.Serialize( writer, envelope, ns );
                    stream.Position = 0;
                    Console.WriteLine( new StreamReader( stream ).ReadToEnd() );
                }
                Console.ReadLine();
            }
        }
    
        [XmlRoot( "cdsXMLEnvelope" )]
        public class CdsXmlEnvelope
        {
            [XmlElement( "TestValue1" )]
            public string TestValue1 { get; set; }
    
            [XmlElement( "inner" )]
            public List<CdsXmlInfo> InnerList { get; set; }
        }
    
        public class CdsXmlInfo
        {
            [XmlElement( "TestValue1" )]
            public string TestValue1 { get; set; }
    
            [XmlAttribute]
            public string TestValue3 { get; set; }
        }
    }
