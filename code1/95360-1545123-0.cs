    [XmlRoot("myObject")]
    public class MyObject
    {
        [XmlElement("myProp", Namespace = "http://www.whited.us")]
        public string MyProp { get; set; }
        [XmlAttribute("myOther", Namespace = "http://www.whited.us")]
        public string MyOther { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var xnames = new XmlSerializerNamespaces();
            xnames.Add("w", "http://www.whited.us");
            var xser = new XmlSerializer(typeof(MyObject));
            using (var ms = new MemoryStream())
            {
                var myObj = new MyObject()
                {
                    MyProp = "Hello",
                    MyOther = "World"
                };
                xser.Serialize(ms, myObj, xnames);
                var res = Encoding.ASCII.GetString(ms.ToArray());
                /*
                    <?xml version="1.0"?>
                    <myObject xmlns:w="http://www.whited.us" w:myOther="World">
                      <w:myProp>Hello</w:myProp>
                    </myObject>
                 */
            }
        }
    }
