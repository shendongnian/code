    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using System.IO;
    using System.Xml;
    using System.Text;
    
    namespace TestSerializeDictionary123
    {
        public class Program
        {
            static void Main(string[] args)
            {
                List<Customer> customers = Customer.GetCustomers();
    
                Console.WriteLine("--- Serializing ------------------");
    
                foreach (var customer in customers)
                {
                    Console.WriteLine("Serializing " + customer.GetFullName() + "...");
                    string xml = XmlHelpers.SerializeObject<Customer>(customer);
                    Console.WriteLine(xml);
                    Console.WriteLine("Deserializing ...");
                    Customer customer2 = XmlHelpers.DeserializeObject<Customer>(xml);
                    Console.WriteLine(customer2.GetFullName());
                    Console.WriteLine("---");
                }
    
                Console.ReadLine();
            }
        }
    
        public static class StringHelpers
        {
            public static String UTF8ByteArrayToString(Byte[] characters)
            {
                UTF8Encoding encoding = new UTF8Encoding();
                String constructedString = encoding.GetString(characters);
                return (constructedString);
            }
    
            public static Byte[] StringToUTF8ByteArray(String pXmlString)
            {
                UTF8Encoding encoding = new UTF8Encoding();
                Byte[] byteArray = encoding.GetBytes(pXmlString);
                return byteArray;
            }
        }
    
        public static class XmlHelpers
        {
            public static string SerializeObject<T>(object o)
            {
                MemoryStream ms = new MemoryStream();
                XmlSerializer xs = new XmlSerializer(typeof(T));
                XmlTextWriter xtw = new XmlTextWriter(ms, Encoding.UTF8);
                xs.Serialize(xtw, o);
                ms = (MemoryStream)xtw.BaseStream;
                return StringHelpers.UTF8ByteArrayToString(ms.ToArray());
            }
    
            public static T DeserializeObject<T>(string xml)
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                MemoryStream ms = new MemoryStream(StringHelpers.StringToUTF8ByteArray(xml));
                XmlTextWriter xtw = new XmlTextWriter(ms, Encoding.UTF8);
                return (T)xs.Deserialize(ms);
            }
        }
    
        public class Customer
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Street { get; set; }
            public string Location { get; set; }
            public string ZipCode { get; set; }
            public SerializableDictionary<string, object> CustomProperties { get; set; }
    
            private int internalValue = 23;
    
            public static List<Customer> GetCustomers()
            {
                List<Customer> customers = new List<Customer>();
                customers.Add(new Customer { Id = 1, FirstName = "Jim", LastName = "Jones", ZipCode = "23434" });
                customers.Add(new Customer { Id = 2, FirstName = "Joe", LastName = "Adams", ZipCode = "12312" });
                customers.Add(new Customer { Id = 3, FirstName = "Jack", LastName = "Johnson", ZipCode = "23111" });
                customers.Add(new Customer { Id = 4, FirstName = "Angie", LastName = "Reckar", ZipCode = "54343" });
    
    
                SerializableDictionary<string, object> customProperties = new SerializableDictionary<string,object>();
                customProperties.Add("datetime", DateTime.Now);
                customProperties.Add("string", "this is a string");
                customProperties.Add("int", 999);
    
                customers.Add(new Customer { Id = 5, FirstName = "Henry", LastName = "Anderson", ZipCode = "16623", CustomProperties = customProperties });
                return customers;
            }
    
            public string GetFullName()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(FirstName + " " + LastName + "(" + internalValue + ")");
    
                if (CustomProperties != null)
                {
                    foreach (var obj in CustomProperties)
                    {
                        sb.Append(", " + obj.Value.GetType().Name);
                    }
                }
    
                return sb.ToString();
    
            }
    
        }
    
        [XmlRoot("dictionary")]
        public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, IXmlSerializable
        {
            #region IXmlSerializable Members
            public System.Xml.Schema.XmlSchema GetSchema()
            {
                return null;
            }
    
            public void ReadXml(System.Xml.XmlReader reader)
            {
                XmlSerializer keySerializer = new XmlSerializer(typeof(TKey));
                XmlSerializer valueSerializer = new XmlSerializer(typeof(TValue));
    
                bool wasEmpty = reader.IsEmptyElement;
                reader.Read();
    
                if (wasEmpty)
                    return;
    
                while (reader.NodeType != System.Xml.XmlNodeType.EndElement)
                {
                    reader.ReadStartElement("item");
    
                    reader.ReadStartElement("key");
                    TKey key = (TKey)keySerializer.Deserialize(reader);
                    reader.ReadEndElement();
    
                    reader.ReadStartElement("value");
                    TValue value = (TValue)valueSerializer.Deserialize(reader);
                    reader.ReadEndElement();
    
                    this.Add(key, value);
    
                    reader.ReadEndElement();
                    reader.MoveToContent();
                }
                reader.ReadEndElement();
            }
    
            public void WriteXml(System.Xml.XmlWriter writer)
            {
                XmlSerializer keySerializer = new XmlSerializer(typeof(TKey));
                XmlSerializer valueSerializer = new XmlSerializer(typeof(TValue));
    
                foreach (TKey key in this.Keys)
                {
                    writer.WriteStartElement("item");
                    writer.WriteStartElement("key");
                    keySerializer.Serialize(writer, key);
    
                    writer.WriteEndElement();
                    writer.WriteStartElement("value");
                    TValue value = this[key];
                    valueSerializer.Serialize(writer, value);
                    writer.WriteEndElement();
    
                    writer.WriteEndElement();
                }
            }
            #endregion
        }
    }
