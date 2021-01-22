    using (var ms = new MemoryStream())
    {
        var msg = new Message();
        Serializer.SerializeWithLengthPrefix(ms, (object)msg, PrefixStyle.Base128); // Casting msg to object breaks the deserialization code.
        ms.Position = 0;
        Serializer.DeserializeWithLengthPrefix<Message>(ms, PrefixStyle.Base128)
    }
