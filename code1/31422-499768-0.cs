    [Serializable(), XmlRoot("root")]
    public class test
    {
        [XmlElement("trees")]
        public List<string> MyProp1 = new List<string>();
        public test()
        {
            MyProp1.Add("some text");
            MyProp1.Add("some more text");
        }
    }
