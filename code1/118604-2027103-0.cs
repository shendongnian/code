    using System;
    using System.Xml.Serialization;
    namespace ConsoleApplication1
    {
        [XmlRoot("MSG")]
        public class XmlMsg
        {
            [XmlElement("ABCID", IsNullable = true)]
            public SubNodes AbcId { get; set; }
            [XmlElement("DATETIME", IsNullable = true)]
            public string DateTime { get; set; }
        }
        public class SubNodes
        {
            [XmlElement("ID", IsNullable = true)]
            public string[] Id { get; set; }
        }
        class Program
        {
            static void Main()
            {
                string value = @"<MSG>
                            <ABCID>
                              <ID>0123456789A</ID>
                              <ID>0123456790B</ID>
                            </ABCID>
                            <DATETIME>2010-01-07T13:00:09</DATETIME>
                            </MSG>";
                try
                {
                    XmlMsg message = (XmlMsg)new XmlSerializer(typeof(XmlMsg)).Deserialize(new System.IO.StringReader(value));
                    foreach (var subNode in message.AbcId.Id)
                    {
                        Console.WriteLine(subNode);
                    }
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                Console.Read();
            }
        }
    }
