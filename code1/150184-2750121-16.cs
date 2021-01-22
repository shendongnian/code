    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Runtime.Serialization.Json;
    using System.Runtime.Serialization;
    using System.IO;
    using System.Diagnostics;
    using System.ComponentModel;
    [DataContract]
    class BookCollection
    {
        [DataMember(Order=1)]
        public string collectionname { get; set; }
        [DataMember(Order = 2)]
        public List<Book> collectionitems { get; set; }
    }
    [CollectionDataContract]
    class Book : ICollection<object>
    {
        public string Id { get; set; }
        public int NumberOfPages { get; set; }
        public string Title { get; set; }
        // code below here is only used for serialization/deserialization
    
        // keeps track of how many properties have been initialized
        [EditorBrowsable(EditorBrowsableState.Never)]
        private int counter = 0;
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Add(object item)
        {
            switch (++counter)
            {
                case 1:
                    Id = (string)item;
                    break;
                case 2:
                    NumberOfPages = (int)item;
                    break;
                case 3:
                    Title = (string)item;
                    break;
                default:
                    throw new NotSupportedException();
            }
        }
    
        [EditorBrowsable(EditorBrowsableState.Never)]
        IEnumerator<object> System.Collections.Generic.IEnumerable<object>.GetEnumerator() 
        {
            return new List<object> { Id, NumberOfPages, Title }.GetEnumerator();
        }
    
        [EditorBrowsable(EditorBrowsableState.Never)]
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() 
        {
            return new object[] { Id, NumberOfPages, Title }.GetEnumerator();
        }
    
        [EditorBrowsable(EditorBrowsableState.Never)]
        int System.Collections.Generic.ICollection<object>.Count 
        { 
            get { return 3; } 
        }
    
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool System.Collections.Generic.ICollection<object>.IsReadOnly 
        { get { throw new NotSupportedException(); } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        void System.Collections.Generic.ICollection<object>.Clear() 
        { throw new NotSupportedException(); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool System.Collections.Generic.ICollection<object>.Contains(object item) 
        { throw new NotSupportedException(); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        void System.Collections.Generic.ICollection<object>.CopyTo(object[] array, int arrayIndex) 
        { throw new NotSupportedException(); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool System.Collections.Generic.ICollection<object>.Remove(object item) 
        { throw new NotSupportedException(); }
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
 
