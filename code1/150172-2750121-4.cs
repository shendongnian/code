    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Runtime.Serialization.Json;
    using System.Runtime.Serialization;
    using System.IO;
    
    [DataContract]
    class BookCollection
    {
        [DataMember(Order=1)]
        public string collectionname { get; set; }
    
        [DataMember(Order = 2)]
        public List<Book> collectionitems { get; set; }
    }
    
    [CollectionDataContract]
    class Book : List<object>
    {
        public string Id { get { return (string)this[0]; } set { this[0] = value; } }
        public int NumberOfPages { get { return (int)this[1]; } set { this[1] = value; } }
        public string Title { get { return (string)this[2]; } set { this[2] = value; } }
    
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(BookCollection));
            string json = "{"
                        + "\"collectionname\":\"Books\","
                        + "\"collectionitems\": [ "
                                + "[\"12345-67890\",201,\"Book One\"],"
                                + "[\"09876-54321\",45,\"Book Two\"]"
                            + "]"
                        + "}";
    
            using (MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                BookCollection obj = ser.ReadObject(ms) as BookCollection;
                using (MemoryStream ms2 = new MemoryStream())
                {
                    ser.WriteObject(ms2, obj);
                    string serializedJson = Encoding.UTF8.GetString(ms2.GetBuffer(), 0,  (int)ms2.Length);
                }
            }
        }
    }
