    [XmlRoot(Namespace = "http://foo")]
    public class MyClass
    {
        private XmlSerializerNamespaces xmlns;
        [XmlNamespaceDeclarations]
        public XmlSerializerNamespaces Xmlns 
        {
            get
            {
                if (xmlns == null)
                {
                    xmlns = new XmlSerializerNamespaces();
                    xmlns.Add("x", "http://xxx");
                }
                return xmlns;
            }
            set { xmlns = value; }
        }
        [XmlAttribute("uid", Namespace = "http://xxx")]
        public int Uid { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var s = new XmlSerializer(typeof(MyClass));
            s.Serialize(Console.Out, new MyClass { Uid = 123 });
            Console.ReadLine();
        }
    }
