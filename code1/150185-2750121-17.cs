    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Runtime.Serialization.Json;
    using System.Runtime.Serialization;
    using System.IO;
    using System.Collections.ObjectModel;
    
    [DataContract]
    class BookCollection
    {
        [DataMember(Order=1)]
        public string collectionname { get; set; }
    
        [DataMember(Order = 2)]
        public List<Book> collectionitems { get; set; }
    }
    
    class Book 
    { 
      public string Id { get; set; } 
      public int NumberOfPages { get; set; } 
      public string Title { get; set; } 
    } 
    
    // A type surrogate substitutes object[] for Book when serializing/deserializing.
    class BookTypeSurrogate : IDataContractSurrogate
    {
        public Type GetDataContractType(Type type)
        {
            // "Book" will be serialized as an object array
            // This method is called during serialization, deserialization, and schema export. 
            if (typeof(Book).IsAssignableFrom(type))
            {
                return typeof(object[]);
            }
            return type;
        }
        public object GetObjectToSerialize(object obj, Type targetType)
        {
            // This method is called on serialization.
            if (obj is Book)
            {
                Book book = (Book) obj;
                return new object[] { book.Id, book.NumberOfPages, book.Title };
            }
            return obj;
        }
        public object GetDeserializedObject(object obj, Type targetType)
        {
            // This method is called on deserialization.
            if (obj is object[])
            {
                object[] arr = (object[])obj;
                Book book = new Book { Id = (string)arr[0], NumberOfPages = (int)arr[1], Title = (string)arr[2] };
                return book;
            }
            return obj;
        }
        public Type GetReferencedTypeOnImport(string typeName, string typeNamespace, object customData)
        {
            return null; // not used
        }
        public System.CodeDom.CodeTypeDeclaration ProcessImportedType(System.CodeDom.CodeTypeDeclaration typeDeclaration, System.CodeDom.CodeCompileUnit compileUnit)
        {
            return typeDeclaration; // Not used
        }
        public object GetCustomDataToExport(Type clrType, Type dataContractType)
        {
            return null; // not used
        }
        public object GetCustomDataToExport(System.Reflection.MemberInfo memberInfo, Type dataContractType)
        {
            return null; // not used
        }
        public void GetKnownCustomDataTypes(Collection<Type> customDataTypes)
        {
            return; // not used
        }
    }
    
    
    class Program
    {
        static void Main(string[] args)
        {
            DataContractJsonSerializer ser  =
                new DataContractJsonSerializer(
                    typeof(BookCollection), 
                    new List<Type>(),        /* knownTypes */
                    int.MaxValue,            /* maxItemsInObjectGraph */ 
                    false,                   /* ignoreExtensionDataObject */
                    new BookTypeSurrogate(),  /* dataContractSurrogate */
                    false                    /* alwaysEmitTypeInformation */
                    );
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
