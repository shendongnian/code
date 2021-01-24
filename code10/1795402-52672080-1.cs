    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    
    namespace TestCodeApp {
        class TestCode {
            static void Main () {
                string xmlString = @"
    <ArrayOfLocation xmlns='http://schemas.datacontract.org/2004/07/Ordinging.Objects' xmlns:i='http://www.w3.org/2001/XMLSchema-instance'>
      <Location>
        <locationID>401</locationID>
        <locationName>Burnaby</locationName>
      </Location>
      <Location>
        <locationID>101</locationID>
        <locationName>Vancouver</locationName>
      </Location>
    </ArrayOfLocation>";
    
                StringReader stringReader = new StringReader (xmlString);
                XmlSerializer serializer = new XmlSerializer (typeof (List<Location>), new XmlRootAttribute ("ArrayOfLocation"));
                List<Location> locations = (List<Location>) serializer.Deserialize (new XmlTextReaderHelper(stringReader));
    
                foreach (Location item in locations) Console.WriteLine (item);
            }
        }
    
        public class XmlTextReaderHelper : XmlTextReader {
            public XmlTextReaderHelper (System.IO.TextReader reader) : base (reader) { }
    
            public override string NamespaceURI {
                get { return ""; }
            }
        }
    
        public class Location {
            public int locationID { get; set; }
            public string locationName { get; set; }
            public override string ToString () {
                return "ID: " + locationID + " - " + locationName;
            }
        }
    }
