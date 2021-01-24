    class Program
    {
        static void Main(string[] args)
        {
            var xml = @"<ArrayOfThemes xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns=""https://brickset.com/api/"">
                <themes>
                <theme>4 Juniors</theme>
                <setCount>24</setCount>
                <subthemeCount>5</subthemeCount>
                <yearFrom>2003</yearFrom>
                <yearTo>2004</yearTo>
                </themes>
                </ArrayOfThemes>";
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(xml));
            var reader = new XmlTextReader(ms) {Namespaces = false};
            var serializer = new XmlSerializer(typeof(ArrayOfThemes));
            
            var result = (ArrayOfThemes) serializer.Deserialize(reader);
        }
    }
    public class Themes
    {
        [XmlElement("theme")]
        public string Theme { get; set; }
        [XmlElement("setCount")]
        public string SetCount { get; set; }
        [XmlElement("subthemeCount")]
        public string SubthemeCount { get; set; }
        [XmlElement("yearFrom")]
        public string YearFrom { get; set; }
        [XmlElement("yearTo")]
        public string YearTo { get; set; }
    }
    [Serializable, XmlRoot("ArrayOfThemes")]
    public class ArrayOfThemes
    {
        [XmlElement("themes")]
        public Themes[] Themes { get; set; }
    }
