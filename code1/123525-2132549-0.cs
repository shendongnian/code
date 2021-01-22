    [SqlFunction]
    public static string ToStringFromBytes(byte[] value) 
    { if (value == null) return null;
    
      using (MemoryStream inMemoryData = new MemoryStream(value))
      {
        return new BinaryFormatter().Deserialize(inMemoryData) as string;
      }
    }
