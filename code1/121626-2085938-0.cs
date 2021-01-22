    using System;
    using System.Xml.Serialization;
    public class Comment
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlText]
        public string Value { get; set; }
    }
    public class Customer
    {
        public int Id { get; set; }
        public Comment Comment { get; set; }
    }
    static class Program
    {
        static void Main()
        {
            Customer cust = new Customer { Id = 1234,
                Comment = new Comment { Name = "abc", Value = "def"}};
            new XmlSerializer(cust.GetType()).Serialize(
                Console.Out, cust);
        }
    }
