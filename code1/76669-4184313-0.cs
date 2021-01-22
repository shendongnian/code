    public static string SerializeToXml(object value)
    {
      StringWriter writer = new StringWriter(CultureInfo.InvariantCulture);
      XmlSerializer serializer = new XmlSerializer(value.GetType());
      serializer.Serialize(writer, value);
      return writer.ToString();
    }
