    public static T DeepClone<T>(T obj)
    {
     using (var ms = new MemoryStream())
     {
       var formatter = new BinaryFormatter();
       formatter.Serialize(ms, obj);
       ms.Location = 0;
    
       return (T) formatter.Deserialize(ms);
     }
    }
