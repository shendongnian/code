    public byte[] ObjectToByteArray(object _Object) {
      using (var stream = new MemoryStream()) {
        // serialize object 
        var formatter = new BinaryFormatter();
        formatter.Serialize(stream, _Object);
        // get a byte array
        return stream.ToArray();
      }
    }
