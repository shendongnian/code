    using System;
    using System.Collections;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    namespace Capishi
    {
        [Serializable]
        public class Conversation
        {
            public Conversation(string convName, string convOwner)
            {
                this.convName = convName;
                this.convOwner = convOwner;
            }
            public Conversation()
            {
            }
            private string convName, convOwner;
            public ArrayList convUsers;
            public string getConvName()
            {
                return this.convName;
            }
            public string getConvOwner()
            {
                return this.convOwner;
            }
        }
        public class SerializationUtils
        {
            public static byte[] SerializeToByteArray(object request)
            {
                byte[] result;
                BinaryFormatter serializer = new BinaryFormatter();
                using (MemoryStream memStream = new MemoryStream())
                {
                    serializer.Serialize(memStream, request);
                    result = memStream.GetBuffer();
                }
                return result;
            }
            public static T DeserializeFromByteArray<T>(byte[] buffer)
            {
                BinaryFormatter deserializer = new BinaryFormatter();
                using (MemoryStream memStream = new MemoryStream(buffer))
                {
                    object newobj = deserializer.Deserialize(memStream);
                    return (T)newobj;
                }
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                // create and initialize a conversation object
                var convName = "Capishi";
                var convOwner = "Ice Cream";
                Conversation myConversation = new Conversation(convName, convOwner);
                myConversation.convUsers = new ArrayList();
                myConversation.convUsers.Add("Ron Klein");
                myConversation.convUsers.Add("Rakesh K");
                // serialize to a byte array
                byte[] data = SerializationUtils.SerializeToByteArray(myConversation);
                // print the resulting byte array if you want
                // PrintArray(data);
                // deserialize the object (on the other side of the communication
                Conversation otherConversation = SerializationUtils.DeserializeFromByteArray<Conversation>(data);
                // let's see if all of the members are really there
                Console.WriteLine("*** start output ***");
                Console.WriteLine("otherConversation.getConvName() = " + otherConversation.getConvName());
                Console.WriteLine("otherConversation.getConvOwner() = " + otherConversation.getConvOwner());
                Console.WriteLine("otherConversation.convUsers:");
                foreach (object item in otherConversation.convUsers)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("*** done output ***");
                // wait before close
                Console.ReadLine();
                
            }
            /// <summary>
            /// just a helper function to dump an array to the console's output
            /// </summary>
            /// <param name="data"></param>
            private static void PrintArray(byte[] data)
            {
                for (int i = 0; i < data.Length; i++)
                {
                    Console.Write("{0:000}", data[i]);
                    if (i < data.Length - 1)
                        Console.Write(", ");
                }
                Console.WriteLine();
            }
        }
    }
