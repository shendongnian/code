    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
    {
        MyMessage message = new MyMessage();
        ProtoBuf.Serializer.Serialize<BaseMessage>(ms, message);
        byte[] buffer = ms.ToArray();
        int messageType = (int)MessageType.MyMessage;
        _socket.Send(BitConverter.GetBytes(messageType));
        _socket.Send(BitConverter.GetBytes(buffer.Length));
        _socket.Send(buffer);
    }
