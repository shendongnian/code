    public T DeserializeMessage<T>(byte[] data) where T:Message
    {
        using (MemoryStream ms = new MemoryStream(data))
        {
            return (T)new BinaryFormatter().Deserialize(ms);
        }
    }
