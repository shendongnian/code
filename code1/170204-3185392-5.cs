    protected override bool Deserialize(string data)
    {
        using(MemoryStream ms = new MemoryStream(Convert.FromBase64String(data)) {
            SerializableContingentOrder sco =
                   Serializer.Deserialize<SerializableContingentOrder>(ms)
        }
        return true;
    }
