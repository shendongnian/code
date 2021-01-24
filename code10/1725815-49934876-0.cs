    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Reflection;
    using System.Xml.Serialization;
    using XML1;
    using XML2;
    
    namespace ConsoleApplication1
    {
        public class Program
        {
            private static void Main(string[] args)
            {
                var list1 = Deserialize<CONSOLIDATED_LIST>(@"CONSOLIDATED_LIST.xml"); // pass the path to your xml here
                var list2 = Deserialize<List>(@"LIST.xml");
            }
    
            public static T Deserialize<T>(string path)
            {
                T obj;            
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                var reader = new StreamReader(path);
                obj = (T)serializer.Deserialize(reader);
                reader.Close();
                return obj;
            }
        }
    }
    
    namespace XML1
    {
        [XmlRoot(ElementName = "INDIVIDUAL_ALIAS")]
        public class INDIVIDUAL_ALIAS
        {
            [XmlElement(ElementName = "QUALITY")]
            public string QUALITY { get; set; }
            [XmlElement(ElementName = "ALIAS_NAME")]
            public string ALIAS_NAME { get; set; }
        }
    
        [XmlRoot(ElementName = "INDIVIDUAL")]
        public class INDIVIDUAL
        {
            [XmlElement(ElementName = "DATAID")]
            public string DATAID { get; set; }
            [XmlElement(ElementName = "VERSIONNUM")]
            public string VERSIONNUM { get; set; }
            [XmlElement(ElementName = "FIRST_NAME")]
            public string FIRST_NAME { get; set; }
            [XmlElement(ElementName = "SECOND_NAME")]
            public string SECOND_NAME { get; set; }
            [XmlElement(ElementName = "INDIVIDUAL_ALIAS")]
            public List<INDIVIDUAL_ALIAS> INDIVIDUAL_ALIAS { get; set; }
        }
    
        [XmlRoot(ElementName = "INDIVIDUALS")]
        public class INDIVIDUALS
        {
            [XmlElement(ElementName = "INDIVIDUAL")]
            public INDIVIDUAL INDIVIDUAL { get; set; }
        }
    
        [XmlRoot(ElementName = "CONSOLIDATED_LIST")]
        public class CONSOLIDATED_LIST
        {
            [XmlElement(ElementName = "INDIVIDUALS")]
            public INDIVIDUALS INDIVIDUALS { get; set; }
            [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
            public string Xsi { get; set; }
            [XmlAttribute(AttributeName = "noNamespaceSchemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
            public string NoNamespaceSchemaLocation { get; set; }
            [XmlAttribute(AttributeName = "dateGenerated")]
            public string DateGenerated { get; set; }
        }
    
    }
    
    namespace XML2
    {
        [XmlRoot(ElementName = "publshInformation", Namespace = "http://tempuri.org/List.xsd")]
        public class PublshInformation
        {
            [XmlElement(ElementName = "Publish_Date", Namespace = "http://tempuri.org/List.xsd")]
            public string Publish_Date { get; set; }
            [XmlElement(ElementName = "Record_Count", Namespace = "http://tempuri.org/List.xsd")]
            public string Record_Count { get; set; }
        }
    
        [XmlRoot(ElementName = "aka", Namespace = "http://tempuri.org/List.xsd")]
        public class Aka
        {
            [XmlElement(ElementName = "category", Namespace = "http://tempuri.org/List.xsd")]
            public string Category { get; set; }
            [XmlElement(ElementName = "lastName", Namespace = "http://tempuri.org/List.xsd")]
            public string LastName { get; set; }
            [XmlElement(ElementName = "fisrtName", Namespace = "http://tempuri.org/List.xsd")]
            public string FisrtName { get; set; }
        }
    
        [XmlRoot(ElementName = "akaList", Namespace = "http://tempuri.org/List.xsd")]
        public class AkaList
        {
            [XmlElement(ElementName = "aka", Namespace = "http://tempuri.org/List.xsd")]
            public List<Aka> Aka { get; set; }
        }
    
        [XmlRoot(ElementName = "sdnEntry", Namespace = "http://tempuri.org/List.xsd")]
        public class SdnEntry
        {
            [XmlElement(ElementName = "lastName", Namespace = "http://tempuri.org/List.xsd")]
            public string LastName { get; set; }
            [XmlElement(ElementName = "fisrtName", Namespace = "http://tempuri.org/List.xsd")]
            public string FisrtName { get; set; }
            [XmlElement(ElementName = "akaList", Namespace = "http://tempuri.org/List.xsd")]
            public AkaList AkaList { get; set; }
        }
    
        [XmlRoot(ElementName = "List", Namespace = "http://tempuri.org/List.xsd")]
        public class List
        {
            [XmlElement(ElementName = "publshInformation", Namespace = "http://tempuri.org/List.xsd")]
            public PublshInformation PublshInformation { get; set; }
            [XmlElement(ElementName = "sdnEntry", Namespace = "http://tempuri.org/List.xsd")]
            public SdnEntry SdnEntry { get; set; }
            [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
            public string Xsi { get; set; }
            [XmlAttribute(AttributeName = "xmlns")]
            public string Xmlns { get; set; }
        }
    }
