    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    
    namespace XmlSerialization
    {
    
        [Serializable]
        public class Child
        {
            public Guid Id { get; set; }
    
            [XmlIgnore] // Don't serialize the reference to the parent
            public Parent parent;
        }
    
        [Serializable]
        public class Parent : IXmlSerializable
        {
            public List<Child> Children;
         
            public Guid Id;
    
            public System.Xml.Schema.XmlSchema GetSchema()
            {
                return null;
            }
    
            public void ReadXml(System.Xml.XmlReader reader)
            {
                XElement xml = XElement.ReadFrom(reader) as XElement;
                if (xml != null)
                {
                    // Deserialize Children
                    Children = 
                        xml.Descendants("Child")
                           .Select(x => new Child() { Id = Guid.Parse(x.Element("Id").Value), parent = this })
                           .ToList();
    
                    // Deserialize Id
                    Id = Guid.Parse(xml.Attribute("Id").Value); 
                }
            }
    
            public void WriteXml(System.Xml.XmlWriter writer)
            {
                // Serialize Id
                writer.WriteAttributeString("Id", Id.ToString());
    
                // Serialize Children
                XmlSerializer childSerializer = new XmlSerializer(typeof(Child));
                foreach (Child child in Children)
                {
                    childSerializer.Serialize(writer, child);
                }
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                Child c1 = new Child { Id = Guid.NewGuid() };
                Child c2 = new Child { Id = Guid.NewGuid() };
    
                Parent p = new Parent { Id = Guid.NewGuid(), Children = new List<Child> { c1, c2 } };
    
                c1.parent = p;
                c2.parent = p;
    
                using (var stream1 = new MemoryStream())
                {
                    XmlSerializer formatter = new XmlSerializer(typeof(Parent), new Type[] { typeof(Child) }) ;
                    formatter.Serialize(stream1, p);
                    stream1.Position = 0;
                    
                    stream1.Position = 0;
    
                    var deserializedParent = formatter.Deserialize(stream1) as Parent;
                    foreach (var child in deserializedParent.Children)
                    {
                        Console.WriteLine(string.Format("Child Id: {0}, Parent Id: {1}", child.Id,  child.parent.Id ));
                    }
                }
    
                Console.ReadLine();
            }
    
        }
    }
