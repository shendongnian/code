    static class Program
    {
        static void Main()
        {
            byte[] blob;
    
            // taken from server code
            using (MemoryStream str = new MemoryStream())
            {
                DiscoverServerMessage message = new DiscoverServerMessage() { Port = 2667, ServerName = "My" };
                message.IP = "127.0.0.1";
    
                Serializer.SerializeWithLengthPrefix(str, message, PrefixStyle.Fixed32);
                blob = str.ToArray();
            }
            System.Console.WriteLine(BitConverter.ToString(blob));
    
            // taken from client code
            using (MemoryStream stream = new MemoryStream(blob))
            {
                DiscoverServerMessage message;
                message = Serializer.DeserializeWithLengthPrefix<DiscoverServerMessage>(stream, PrefixStyle.Fixed32);
                Console.WriteLine(message.Port);
                Console.WriteLine(message.ServerName);
                Console.WriteLine(message.IP);
            }
    
        }
    }
