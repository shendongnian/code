    public class MyObject
    {
        [XmlArrayItemAttribute("MyInnerObjectProperty", typeof (MyInnerObject),
            IsNullable = false)]
        [XmlArray(Namespace = "http://foo.com/2009")]
        public MyInnerObject[] MyInnerObjectProperties { get; set; }
    }
