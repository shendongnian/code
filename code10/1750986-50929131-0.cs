    public class Mymodel
    {
        // const normally are UPPERCASE
        private const string DEC = "declaration";
        private const string ABC= "declaration";
        public class InnerClass
        {
            [XmlElement( ElementName = "InnerItem", typeof(string), Namespace = ABC)]
            public string InnerItem { get; set; }
        }
        [XmlElement( ElementName = "Item1", DataType = "string", Namespace = DEC)]
        public string Item1{ get; set; }
    
        
        public Mymodel
        {
        }
        public Mymodel(string item, InnerClass inner)
        {
            this.Item1 = item;
            this.InnerClass = inner;
        }
    }
