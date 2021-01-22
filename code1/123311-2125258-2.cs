    [XmlRoot("NameOfRootElement")]
    public class MyWrapper {
        private List<MyTest> items = new List<MyTest>();
        [XmlElement("NameOfChildElement")]
        public List<MyTest> Items { get { return items; } }
    }
    static void Main() {
        MyTest test = new MyTest();
        test.Test = "gog";
        MyWrapper wrapper = new MyWrapper {
            Items = {  test }
        };
        SerializeToXML(wrapper);
    }
    static public void SerializeToXML(MyWrapper list) {
        XmlSerializer serializer = new XmlSerializer(typeof(MyWrapper));
        using (TextWriter textWriter = new StreamWriter(@"test.xml")) {
            serializer.Serialize(textWriter, list);
            textWriter.Close();
        }
    }
