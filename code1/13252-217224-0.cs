    using System.Runtime.Serialization.Formatters.Binary;
    using System.IO;
    using System.Data.SqlClient;
    using System.Runtime.Serialization;
    public byte[] SerializeList<T>(List<T> list)
    {
    
        MemoryStream ms = new MemoryStream();
    
        BinaryFormatter bf = new BinaryFormatter();
    
        bf.Serialize(ms, list);
    
        ms.Position = 0;
    
        byte[] serializedList = new byte[ms.Length];
    
        ms.Read(serializedList, 0, (int)ms.Length);
    
        ms.Close();
    
        return serializedList; 
    
    } 
    
    public List<T> DeserializeList<T>(byte[] data)
    {
        try
        {
            MemoryStream ms = new MemoryStream();
            ms.Write(data, 0, data.Length);
            ms.Position = 0;
            BinaryFormatter bf = new BinaryFormatter();
            List<T> list = bf.Deserialize(ms) as List<T>;
            return list;
        }
        catch (SerializationException ex)
        {
            // Handle deserialization problems here.
            Debug.WriteLine(ex.ToString());
            return null;
        }
    }
