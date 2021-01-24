    public enum SimpleEnum : byte
    {
        one = 0x01,
        two = 0x02,
        three = 0x03
    }
    public class Foo
    {
        private Enum _simple;
        [XmlIgnore]
        public Enum Simple
        {
            get { return _simple; }
            set {
                _simple = value;
                var type = Simple.GetType();
                var underlyingType = Enum.GetUnderlyingType(type);
                EnumType = Simple.GetType().FullName;
                EnumMember = Simple.ToString();
            }
        }
        private string _enumType;
        public string EnumType
        {
            get { return _enumType; }
            set { _enumType = value; }
        }
        private string _enumMember;
        public string EnumMember
        {
            get { return _enumMember; }
            set {
                _enumMember = value;
                _simple = (Enum)Enum.Parse(Type.GetType(EnumType), EnumMember);
            }
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            var str = new StringBuilder();
            using (var writer = XmlWriter.Create(str))
            {
                try
                {
                    var foo = new Foo
                    {
                        Simple = SimpleEnum.three
                    };
                    var serializer = new XmlSerializer(typeof(Foo));
                    serializer.Serialize(writer, foo);
                    Console.WriteLine(str.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            using (TextReader reader = new StringReader(str.ToString()))
            {
                try
                {
                    var serializer = new XmlSerializer(typeof(Foo));
                    var foo = (Foo)serializer.Deserialize(reader);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            Console.ReadLine();
        }
    }
