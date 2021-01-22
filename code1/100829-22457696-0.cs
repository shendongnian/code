    public class Test
    {
        public text Text;
    
        public Test()
        {
            Text = new text();
        }
    
        [DataContract(Name = "Test", Namespace = "")]
        public class text
        {
            [XmlText]
            public string Text { get; set; }
            [XmlAttribute]
            public string type { get; set; }
        }
    }
