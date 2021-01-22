    namespace Cheeso.Xml.Samples.Arrays
    {
        static class Extensions
        {
            private static XmlSerializerNamespaces _ns;
            static Extensions()
            {
                // to suppress unused default namespace entries in the root elt
                _ns = new XmlSerializerNamespaces();
                _ns.Add( "", "" );
            }
            public static string SerializeToString(this XmlSerializer s, object o)
            {
                var builder = new System.Text.StringBuilder();
                var settings = new System.Xml.XmlWriterSettings { OmitXmlDeclaration = true, Indent= true };
                using ( var writer = System.Xml.XmlWriter.Create(builder, settings))
                {
                    s.Serialize(writer, o, _ns);
                }
                return builder.ToString();
            }
        }
        [XmlType("ArrayOfString")]
        public class MyContainer
        {
            [XmlIgnore]
            public String[] a;
            // surrogate property
            [XmlElement("string")]
            public String[] A
            {
                get
                {
                    List<String> _proxy = new List<String>();
                    foreach (var s in a)
                    {
                        if (!String.IsNullOrEmpty(s))
                            _proxy.Add(s);
                    }
                    return _proxy.ToArray();
                }
                set
                {
                    a = value;
                }
            }
        }
        class StringArrayOnlyNonEmptyItems
        {
            static void Main(string[] args)
            {
                try 
                {
                    Console.WriteLine("\nRegular Serialization of an array of strings with some empty elements:");
                    String[] x = { "AAA", "BBB",  "",  "DDD",  "", "FFF" };
                    XmlSerializer s1 = new XmlSerializer(typeof(String[]));
                    string s = s1.SerializeToString(x);
                    Console.WriteLine(s);
                    Console.WriteLine("\nSerialization of an array of strings with some empty elements, via a Container:");
                    MyContainer c = new MyContainer();
                    c.a = x;
                    XmlSerializer s2 = new XmlSerializer(typeof(MyContainer));
                    s = s2.SerializeToString(c);
                    Console.WriteLine(s);
                }
                catch (System.Exception exc1)
                {
                    Console.WriteLine("uncaught exception:\n{0}", exc1);
                }
            }
        }
    }
