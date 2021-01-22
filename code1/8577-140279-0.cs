    object deepcopy = FromBinary(ToBinary(yourDictionary));
    public Byte[] ToBinary()
    {
      MemoryStream ms = null;
      Byte[] byteArray = null;
      try
      {
        BinaryFormatter serializer = new BinaryFormatter();
        ms = new MemoryStream();
        serializer.Serialize(ms, this);
        byteArray = ms.ToArray();
      }
      catch (Exception unexpected)
      {
        Trace.Fail(unexpected.Message);
        throw;
      }
      finally
      {
        if (ms != null)
          ms.Close();
      }
      return byteArray;
    }
    public object FromBinary(Byte[] buffer)
    {
      MemoryStream ms = null;
      object deserializedObject = null;
      try
      {
        BinaryFormatter serializer = new BinaryFormatter();
        ms = new MemoryStream();
        ms.Write(buffer, 0, buffer.Length);
        ms.Position = 0;
        deserializedObject = serializer.Deserialize(ms);
      }
      finally
      {
        if (ms != null)
          ms.Close();
      }
      return deserializedObject;
    }
