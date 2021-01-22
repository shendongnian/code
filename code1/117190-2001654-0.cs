    static void Main(string[] args)
            {
                var str = "Hello World";
    
                var stream = Serialize(str);
                stream.Position = 0;
                var str2 = DeSerialize(stream);
    
                Console.WriteLine(str2);
                Console.ReadLine();
            }
    
            public static object DeSerialize(MemoryStream stream)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                return formatter.Deserialize(stream);
            }
            public static MemoryStream Serialize(object data)
            {
    
                MemoryStream streamMemory = new MemoryStream();
                BinaryFormatter formatter = new BinaryFormatter();
    
                formatter.Serialize(streamMemory, data);
    
                return streamMemory;
    
            }
