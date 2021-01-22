    protected override string Serialize()
    {
        SerializableContingentOrder sco = new SerializableContingentOrder(this);   
        using(MemoryStream ms = new MemoryStream()) {
            Serializer.Serialize(ms, sco);
            return Convert.ToBase64String(ms.ToArray());
        }
    }
