    [XmlRoot("Response", Namespace="http://www.thirdparty.com/lr/")]
    public class ResponseExt : Response {
    }
    [XmlRoot("Response", Namespace="http://www.thirdparty.com/lr/")]
    [XmlInclude(typeof(ResponseExt))]
    public class Response {
        public string Code {get; set;}
        public string Message {get; set;}
        public string SessionId {get; set;}
    }
    public class XsiType
    {
        public static void Main(string[] args)
        {
            try
            {
                string filename = "XsiType.xml";
                XmlSerializer s1 = new XmlSerializer(typeof(Response));
                ResponseExt r = null;
                using(System.IO.StreamReader reader= System.IO.File.OpenText(filename))
                {
                    r= (ResponseExt) s1.Deserialize(reader);
                }
                var builder = new System.Text.StringBuilder();
                var xmlws = new System.Xml.XmlWriterSettings { OmitXmlDeclaration = true, Indent= true };
                using ( var writer = System.Xml.XmlWriter.Create(builder, xmlws))
                {
                    //s1.Serialize(writer, r, ns);
                    s1.Serialize(writer, r);
                }
                string xml = builder.ToString();
                System.Console.WriteLine(xml);
            }
            catch (System.Exception exc1)
            {
                Console.WriteLine("Exception: {0}", exc1.ToString());
            }
        }
    }
