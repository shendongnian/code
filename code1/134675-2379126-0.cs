    [XmlRoot(Namespace="urn:organisationMetaDataSchema")]
    public class Organisations
    {
        private readonly List<Organisation> items = new List<Organisation>();
        [XmlElement("Organisation")]
        public List<Organisation> Items { get { return items; } }
    }
    public class Organisation
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    static class Program
    {
        static void Main()
        {
            string xml = @"<?xml version='1.0' encoding='utf-8' standalone='yes'?><Organisations xmlns='urn:organisationMetaDataSchema'><Organisation><Code>XXXX</Code><Name>YYYYYYYY</Name></Organisation></Organisations>";
            XmlSerializer ser = new XmlSerializer(typeof(Organisations));
            using (Stream input = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
            {
                Organisations orgs = (Organisations)ser.Deserialize(input);
            }
        }
    }
