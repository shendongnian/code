    public static void Save(object obj)
    {
        using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
        {
            // Serialize an object into the storage referenced by 'stream' object.
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            // Serialize multiple objects into the stream
            formatter.Serialize(stream, obj);
            // If you want to put the stream into Array of byte use below code
            // byte[] buffer = stream.ToArray();
        }
    }
