    class Program
    {
        static void Main(string[] args)
        {
            XmlSerializer s = new XmlSerializer(typeof(FooContainer));
    
            var str = new StringWriter();
            var fc  = new FooContainer();
    
            var lst = new List<Foo>() { new Foo(), new Foo(), new Foo() };
    
            fc.lst.Add( lst );
    
            s.Serialize(str, fc);
        }
    }
    
    [XmlRoot("Foo")]    
    public class Foo    {        
        [XmlElement("name")]        
        public string name = String.Empty;    }    
    
    [XmlRoot("FooContainer")]    
    public class FooContainer    {
    
        public List<List<Foo>> _lst = new List<List<Foo>>();
        public FooContainer()
        {
    
        }
    
        [XmlArrayItemAttribute()]
        public List<List<Foo>> lst { get { return _lst; } }
    }
