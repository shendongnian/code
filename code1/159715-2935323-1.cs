    [WebMethod]
    public void Reports(byte[] data)
    {
      BinaryFormatter bf = new BinaryFormatter();
      object obj = bf.Deserialize(new MemoryStream(data));
      // use the deserialized object
    }
