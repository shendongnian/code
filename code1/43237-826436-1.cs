    protected bool EvaluateBuffer(byte[] buffer, int length)
    {
        if (length < 8)
        {
            return false;
        }
        MessageType messageType = (MessageType)BitConverter.ToInt32(buffer, 0);
        int size = BitConverter.ToInt32(buffer, 4);
        if (length < size + 8)
        {
            return false;
        }
        using (MemoryStream memoryStream = new MemoryStream(buffer))
        {
            memoryStream.Seek(8, SeekOrigin.Begin);
            if (messageType == MessageType.MyMessage)
            {
                MyMessage message = 
                    ProtoBuf.Serializer.Deserialize<MyMessage>(memoryStream);
            }
        }
    }
