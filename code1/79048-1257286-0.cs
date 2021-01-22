    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    public class Data
    {
    
        [XmlArray("Times")]
        [XmlArrayItem("Time")]
        public List<DateTime> Times { get; set; }
    
        static void Main()
        {
            XmlReader xr = XmlReader.Create(new StringReader(@"<Data><Times>
      <Time>1900-01-01T00:00:00</Time>
      <Time>1900-01-01T06:00:00</Time>
    </Times></Data>"));
            XmlSerializer ser = new XmlSerializer(typeof(Data));
            Data data = (Data) ser.Deserialize(xr);
            // use data
        }
    }
