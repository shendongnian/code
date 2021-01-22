    [ProtoAfterDeserialization()]
    public void OnProtoAfterDeserialization()
    {
        Console.WriteLine("called OnProtoAfterDeserialization");
        bool ret = Enum.TryParse(m_rotate.ToString(), out m_rotate_protobuf);
    }
    
    [ProtoBeforeSerialization()]
    public void OnProtoBeforeSerialization()
    {
        Console.WriteLine("called OnProtoBeforeSerialization");
        bool ret = Enum.TryParse(m_rotate_protobuf.ToString(), out m_rotate);
    }
