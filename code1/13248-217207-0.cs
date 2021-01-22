    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.Serialization;
    using System.IO;
    namespace SerializeThingy
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<string> myList = new List<string>();
                myList.Add("One");
                myList.Add("Two");
                myList.Add("Three");
                NetDataContractSerializer serializer = new NetDataContractSerializer();
                MemoryStream stream = new MemoryStream();
                serializer.Serialize(stream, myList);
                stream.Position = 0;
                Console.WriteLine(ASCIIEncoding.ASCII.GetString(stream.ToArray()));
                List<string> myList2 = (List<string>)serializer.Deserialize(stream);
                Console.WriteLine(myList2[0]);
                Console.ReadKey();
            }
        }
    }
