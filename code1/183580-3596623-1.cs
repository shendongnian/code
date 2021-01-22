    public class XmlTextWriterFull : XmlTextWriter
    {
        public XmlTextWriterFull(TextWriter sink) : base(sink) { }
        public override void WriteEndElement()
        {
            base.WriteFullEndElement();
        }
        public override void WriteStartDocument()
        {
            base.WriteRaw("<?xml version=\"1.0\"?>");
        }
    }
    public class temp
    {
        public int a = 0;
        public List<int> x = new List<int>();
    }
    class Program
    {
        static void Main(string[] args)
        {
            XmlTextWriterFull writer = new XmlTextWriterFull(Console.Out);
            XmlSerializer xs = new XmlSerializer(typeof(temp));
            xs.Serialize(writer,new temp());
            Console.ReadKey();
        }
    }
