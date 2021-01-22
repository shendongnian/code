    public class ComponentsMessage
    {
        public NetworkComponent[] Components { get; set; }
    }
    class Program
    {
        static void Main()
        {
            NetworkComponent[] _updatedComponents = new NetworkComponent[2] {
                new NetworkComponent{},new NetworkComponent{}
            };
            const string XmlNamespace = "http://www.xxx.com/nis/componentsync";
            XmlAttributeOverrides ao = new XmlAttributeOverrides();
            ao.Add(typeof(ComponentsMessage), new XmlAttributes {
                XmlRoot = new XmlRootAttribute("components") { Namespace = XmlNamespace },
                XmlType = new XmlTypeAttribute("components") { Namespace = XmlNamespace }
            });
            ao.Add(typeof(ComponentsMessage), "Components", new XmlAttributes {
                XmlElements =  {
                    new XmlElementAttribute("component")
                }
            });
            ComponentsMessage msg = new ComponentsMessage { Components = _updatedComponents };
            XmlSerializer serializer = new XmlSerializer(msg.GetType(), ao);
            serializer.Serialize(Console.Out, msg);
        }
    }
