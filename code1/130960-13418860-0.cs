    class Program
    {
        static void Main(string[] args)
        {
            //create list to serialize
            Person personA = new Person() { Name = "Bob", Age = 10, StartDate = DateTime.Parse("1/1/1960"), Money = 123456m };
            List<Person> listA = new List<Person>();
            for (int i = 0; i < 10; i++)
            {
                listA.Add(personA);
            }
            //serialize list to file
            XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));
            XmlTextWriter writer = new XmlTextWriter("Test.xml", Encoding.UTF8);
            serializer.Serialize(writer, listA);
            writer.Close();
            //deserialize list from file
            serializer = new XmlSerializer(typeof(List<ProxysNamespace.Person>));
            List<ProxysNamespace.Person> listB;
            using (FileStream file = new FileStream("Test.xml", FileMode.Open))
            {
                //configure proxy reader
                XmlSoapProxyReader reader = new XmlSoapProxyReader(file);
                reader.ProxyNamespace = "http://myappns.com/";      //the namespace of the XmlTypeAttribute 
                reader.ProxyType = typeof(ProxysNamespace.Person); //the type with the XmlTypeAttribute
                //deserialize
                listB = (List<ProxysNamespace.Person>)serializer.Deserialize(reader);
            }
            //display list
            foreach (ProxysNamespace.Person p in listB)
            {
                Console.WriteLine(p.ToString());
            }
            Console.ReadLine();
        }
    }
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime StartDate { get; set; }
        public decimal Money { get; set; }
    }
    namespace ProxysNamespace
    {
        [XmlTypeAttribute(Namespace = "http://myappns.com/")]
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public DateTime Birthday { get; set; }
            public decimal Money { get; set; }
            public override string ToString()
            {
                return string.Format("{0}:{1},{2:d}:{3:c2}", Name, Age, Birthday, Money);
            }
        }
    }
    public class XmlSoapProxyReader : XmlTextReader
    {
        List<object> propNames;
        public XmlSoapProxyReader(Stream input)
            : base(input)
        {
            propNames = new List<object>();
        }
        public string ProxyNamespace { get; set; }
        private Type proxyType;
        public Type ProxyType
        {
            get { return proxyType; }
            set
            {
                proxyType = value;
                PropertyInfo[] properties = proxyType.GetProperties();
                foreach (PropertyInfo p in properties)
                {
                    propNames.Add(p.Name);
                }
            }
        }
        public override string NamespaceURI
        {
            get
            {
                object localname = LocalName;
                if (propNames.Contains(localname))
                    return ProxyNamespace;
                else
                    return string.Empty;
            }
        }
    }
