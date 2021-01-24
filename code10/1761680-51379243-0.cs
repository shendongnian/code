    static DataTable FromBytes(byte[] arr)
    {
        using (var ms = new MemoryStream(arr))
        {
            return (DataTable)new BinaryFormatter().Deserialize(ms);
        }
    }
    static byte[] ToBytes(DataTable table)
    {
        using (var ms = new MemoryStream())
        {
            table.RemotingFormat = SerializationFormat.Binary;
            new BinaryFormatter().Serialize(ms, table);
            return ms.ToArray();
        }            
    }
