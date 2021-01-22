    private static readonly Dictionary<Type, XmlSerializer> serialisers = new Dictionary<Type, XmlSerializer>();
    /// <summary>Serialises an object of type T in to an xml string</summary>
    /// <typeparam name="T">Any class type</typeparam>
    /// <param name="objectToSerialise">Object to serialise</param>
    /// <returns>A string that represents Xml, empty oterwise</returns>
    public static string XmlSerialise<T>(this T objectToSerialise) where T : class, new()
    {
      XmlSerializer serialiser;
      var type = typeof(T);
      if (!serialisers.ContainsKey(type))
      {
        serialiser = new XmlSerializer(type);
        serialisers.Add(type, serialiser);
      }
      else
      {
        serialiser = serialisers[type];
      }
      string xml;
      using (var writer = new StringWriter())
      {
        serialiser.Serialize(writer, objectToSerialise);
        xml = writer.ToString();
      }
      return xml;
    }
    /// <summary>Deserialises an xml string in to an object of Type T</summary>
    /// <typeparam name="T">Any class type</typeparam>
    /// <param name="xml">Xml as string to deserialise from</param>
    /// <returns>A new object of type T is successful, null if failed</returns>
    public static T XmlDeserialise<T>(this string xml) where T : class, new()
    {
      XmlSerializer serialiser;
      var type = typeof(T);
      if (!serialisers.ContainsKey(type))
      {
        serialiser = new XmlSerializer(type);
        serialisers.Add(type, serialiser);
      }
      else
      {
        serialiser = serialisers[type];
      }
      T newObject;
      using (var reader = new StringReader(xml))
      {
        try { newObject = (T)serialiser.Deserialize(reader); }
        catch { return null; } // Could not be deserialized to this type.
      }
      return newObject;
    }
