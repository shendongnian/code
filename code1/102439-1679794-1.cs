    public static ObjectType CopyObject<ObjectType>(ObjectType oObject)
    {
      XmlSerializer oSeializer = null;
      // Creates the serializer
      oSeializer = new XmlSerializer(oObject.GetType());
      //Use the stream
      using (MemoryStream oStream = new MemoryStream())
      {
        // Serialize the object
        oSeializer.Serialize(oStream, oObject);
        // Set the strem position
        oStream.Position = 0;
        // Return the object
        return (ObjectType)oSeializer.Deserialize(oStream);
      }
    }
