    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    
    namespace TestCodeApp {
        class TestCode {
            static void Main () {
                string xmlString = @"
    <ArrayOfLocation>
      <Location>
        <locationID>401</locationID>
        <locationName>Burnaby</locationName>
      </Location>
      <Location>
        <locationID>101</locationID>
        <locationName>Vancouver</locationName>
      </Location>
    </ArrayOfLocation>";
    
                StringReader stringReader = new StringReader(xmlString);
                XmlSerializer serializer = new XmlSerializer(typeof(List<Location>), new XmlRootAttribute("ArrayOfLocation"));
                List<Location> locations = (List<Location>)serializer.Deserialize(stringReader);
    
                foreach (Location item in locations) Console.WriteLine(item);
            }
        }
    
        public class Location
        {
            public int locationID { get; set; }
            public string locationName { get; set; }
            public override string ToString()
            {
                return "ID: " + locationID + " - " + locationName;
            }
        }
    }
