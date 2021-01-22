    public class FooParent
    {
        [XmlArrayItem(ElementName="Foo",
                      Namespace="http://schemas.datacontract.org/2004/07/JezNamespace")]
        public List<Foo> Foos { get; private set; }
    }
