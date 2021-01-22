    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Security.Permissions;
    
    namespace DataContractJsonSerializer {
        [DataContract]
        class BookCollection {
            [DataMember (Order = 0)]
            public string collectionname { get; set; }
            [DataMember (Order = 1)]
            public List<Book> collectionitems { get; set; }
        }
    
        [Serializable]
        [KnownType (typeof (object[]))]
        class Book: ISerializable {
            public string Id { get; set; }
            public int NumberOfPages { get; set; }
            public string Title { get; set; }
    
            public Book () { }
    
            [SecurityPermissionAttribute (SecurityAction.Demand, Flags = SecurityPermissionFlag.SerializationFormatter)]
            protected Book (SerializationInfo info, StreamingContext context) {
                // called by DataContractJsonSerializer.ReadObject
                Object[] ar = (Object[]) info.GetValue ("book", typeof (object[]));
                
                this.Id = (string)ar[0];
                this.NumberOfPages = (int)ar[1];
                this.Title = (string)ar[2];
            }
    
            [SecurityPermission (SecurityAction.Demand, SerializationFormatter = true)]
            public void GetObjectData (SerializationInfo info, StreamingContext context) {
                // called by DataContractJsonSerializer.WriteObject
                object[] ar = new object[] { (object)this.Id, (object)this.NumberOfPages, (object)this.Title };
                info.AddValue ("book", ar);
            }
        }
    
        class Program {
            static readonly string testJSONdata = "{\"collectionname\":\"Books\",\"collectionitems\":[{\"book\":[\"12345-67890\",201,\"Book One\"]},{\"book\":[\"09876-54321\",45,\"Book Two\"]}]}";
    
            static void Main (string[] args) {
                BookCollection test = new BookCollection () {
                    collectionname = "Books",
                    collectionitems = new List<Book> {
                        new Book() { Id = "12345-67890", NumberOfPages = 201, Title = "Book One"},
                        new Book() { Id = "09876-54321", NumberOfPages = 45, Title = "Book Two"},
                    }
                };
    
                MemoryStream memoryStream = new MemoryStream ();
                System.Runtime.Serialization.Json.DataContractJsonSerializer ser =
                    new System.Runtime.Serialization.Json.DataContractJsonSerializer (typeof (BookCollection));
                memoryStream.Position = 0;
                ser.WriteObject (memoryStream, test);
    
                memoryStream.Flush();
                memoryStream.Position = 0;
                StreamReader sr = new StreamReader(memoryStream);
                string str = sr.ReadToEnd ();
                Console.WriteLine ("The result of custom serialization:");
                Console.WriteLine (str);
    
                if (String.Compare (testJSONdata, str, StringComparison.Ordinal) != 0) {
                    Console.WriteLine ("Error in serialization: unexpected results.");
                        return;
                }
    
                byte[] jsonDataAsBytes = System.Text.Encoding.GetEncoding ("iso-8859-1").GetBytes (testJSONdata);
                MemoryStream stream = new MemoryStream (jsonDataAsBytes);
                stream.Position = 0;
                BookCollection p2 = (BookCollection)ser.ReadObject (stream);
            }
        }
    }
