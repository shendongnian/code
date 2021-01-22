    using System;
    using System.Xml.Serialization;
    [XmlRoot(Namespace="http://schemas.xmlsoap.org/soap/envelope/")]
    public class Envelope {
        public Body Body { get; set; }
    }
    public class Body {
        [XmlElement(Namespace="http://schemas.mycorp.com/test")]
        public QueryResponse QueryResponse { get; set; }
    }
    public class QueryResponse {
        public Faculties Faculties { get; set; }
    }
    public class Faculties {
        public string Name { get; set; }
    }
    static class Program {
        static void Main() {
            XmlSerializer ser = new XmlSerializer(typeof(Envelope));
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            ns.Add("soapenv", "http://schemas.xmlsoap.org/soap/envelope/");
            Envelope env = new Envelope {
                Body = new Body {
                    QueryResponse = new QueryResponse {
                         Faculties = new Faculties { Name = "John"}
                    }
                }
            };
            ser.Serialize(Console.Out, env, ns);
        }
    }
