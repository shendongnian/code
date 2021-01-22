    using System;
    using System.IO;
    using System.Runtime.Serialization;
    class DataContractTest
    {
        static void Main(string[] args)
        {
          var serializer = new DataContractSerializer(typeof(NoParameterLessConstructor));
          
          var obj1 = new NoParameterLessConstructor("Name", 1);
          
          var ms = new MemoryStream();
          serializer.WriteObject(ms, obj1);
          
          ms.Seek(0, SeekOrigin.Begin);
          
          var obj2 = (NoParameterLessConstructor)serializer.ReadObject(ms);
          
          Console.WriteLine("obj2.Name: {0}", obj2.Name);
          Console.WriteLine("obj2.Version: {0}", obj2.Version);
        }
        
        [DataContract]
        class NoParameterLessConstructor
        {
            public NoParameterLessConstructor(string name, int version)
            {
              Name = name;
              Version = version;
            }
            
            [DataMember]
            public string Name { get; private set; }
            [DataMember]
            public int Version { get; private set; }
        }
    }
