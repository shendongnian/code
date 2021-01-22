      public static MemoryStream Serialize(object data)
        {
        
            MemoryStream streamMemory = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.AssemblyFormat = FormatterAssemblyStyle.Simple;
        
            formatter.Serialize(streamMemory, data);
        
            return streamMemory;
        
        
        }
 
       public static Object Deserialize(MemoryStream stream)
        {
    
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.AssemblyFormat = FormatterAssemblyStyle.Simple;
            return formatter.Deserialize(stream);
            
        }
