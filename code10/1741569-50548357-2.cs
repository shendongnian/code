    public static void Serialize(Dictionary<DateTime, int> dictionary, Stream stream)
    {
       var writer = new BinaryWriter(stream);
       writer.Write(dictionary.Count);
       foreach (var kvp in dictionary)
       {
          writer.Write(kvp.Key.ToBinary());
          writer.Write(kvp.Value);
       }
    
       writer.Flush();
    }
    
    public static Dictionary<DateTime, int> Deserialize(Stream stream)
    {
       var reader = new BinaryReader(stream);
       var count = reader.ReadInt32();
       var dictionary = new Dictionary<DateTime, int>(count);
       for (var n = 0; n < count; n++)
       {
          var key = DateTime.FromBinary(reader.ReadInt64());
          var value = reader.ReadInt32();
          dictionary.Add(key, value);
       }
    
       return dictionary;
    }
