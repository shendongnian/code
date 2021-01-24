    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlReader reader = XmlReader.Create(FILENAME);
                XmlSerializer serializer = new XmlSerializer(typeof(Response));
                Response response = (Response)serializer.Deserialize(reader);
            }
        }
        [XmlRoot("Response")]
        public class Response
        {
            [XmlElement("ResponseTransaction")]
            public ResponseTransaction responseTransaction { get; set; }
        }
        [XmlRoot("ResponseTransaction")]
        public class ResponseTransaction
        {
            [XmlElement("transaction")]
            public Transaction transaction { get; set; }
        }
        [XmlRoot("transaction")]
        public class Transaction
        {
            [XmlElement("tranId")]
            public string TranId { get; set; }
            [XmlElement("tranName")]
            public string TranName { get; set; }
            [XmlArray("tranResultList")]
            [XmlArrayItem("tranResult")]
            public List<TranResult> TranResultList { get; set; }
        }
        public class TranResult
        {
            [XmlElement("state")]
            public string State { get; set; }
            [XmlElement("created")]
            public string DateCreated { get; set; }
            [XmlArray("docList")]
            [XmlArrayItem("doc")]
            public List<Document> DocumentList { get; set; }
            [XmlArray("roleList")]
            [XmlArrayItem("role")]
            public List<Role> RoleList { get; set; }
        }
        public class Document
        {
            [XmlAttribute("id")]
            public string Id { get; set; }
            [XmlAttribute("name")]
            public string Name { get; set; }
            [XmlAttribute("status")]
            public string status { get; set; }
        }
        public class Role
        {
            private User user = new User();
            [XmlAttribute("id")]
            public string Id { get; set; }
            [XmlAttribute("role")]
            public string RoleName { get; set; }
            [XmlElement("firstName")]
            public string FirstName {
                get { return user.FirstName; }
                set { user.FirstName = value; }
            }
            [XmlElement("lastName")]
            public string LastName
            {
                get { return user.LastName; }
                set { user.LastName = value; }
            }
            [XmlElement("email")]
            public string Email
            {
                get { return user.Email; }
                set { user.Email = value; }
            }
            [XmlArray("docList")]
            [XmlArrayItem("doc")]
            public List<Document> DocumentList {
                get { return user.DocumentList; }
                set { user.DocumentList = value; } 
            }
        }
        public class User
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public List<Document> DocumentList { get; set; }
        }
    }
