    class Program
    {
        static void Main(string[] args)
        {
            XmlSerializer s = new XmlSerializer(typeof(MyClass));
            MyClass myClass = null;
            using (var sr = new StringReader(@"<myXml><updateDate>20181008</updateDate><someProp>Hello, world</someProp></myXml>"))            
                myClass = s.Deserialize(sr) as MyClass;            
            DateTime? myValue = myClass.SomeDate;
            Console.WriteLine($"{myClass.SomeDate}");
            Console.ReadKey();
        }
    }
    [XmlRoot("myXml")]
    public class MyClass
    {
        [XmlElement("updateDate")]
        public CustomDateTime SomeDate { get; set; }
        [XmlElement("someProp")]
        public string SomeProp { get; set; }
    }
    public class CustomDateTime : IXmlSerializable
    {
        public DateTime? _dateTime { get; set; }
        private const string EXPECTED_FORMAT = "yyyyMMdd";
        public XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }
        public void ReadXml(XmlReader reader)
        {
            var elementContent = reader.ReadElementContentAsString();
            _dateTime = String.IsNullOrWhiteSpace(elementContent) ? (DateTime?)null : DateTime.ParseExact(elementContent, EXPECTED_FORMAT, CultureInfo.InvariantCulture);
        }
        public void WriteXml(XmlWriter writer)
        {
            if (!_dateTime.HasValue) return;
            writer.WriteString(_dateTime.Value.ToString(EXPECTED_FORMAT));
        }
        public static implicit operator DateTime? (CustomDateTime input)
        {
            return input._dateTime;
        }
        public static implicit operator CustomDateTime (DateTime input)
        {
            return new CustomDateTime() { _dateTime = input };
        }
        public override string ToString()
        {
            if (_dateTime == null) return null;
            return _dateTime.Value.ToString();
        }
    }
