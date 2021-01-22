    public interface MXmlSerializable { }
    public static class XmlSerializable {
      public static string ToXml(this MXmlSerializable self) {
        if (self == null) throw new NullReferenceException();
        var serializer = new XmlSerializer(self.GetType());
        using (var writer = new StringWriter()) {
          serializer.Serialize(writer, self);
          return writer.GetStringBuilder().ToString();
        }
      }
      public static T FromXml<T>(string xml) where T : MXmlSerializable {
        var serializer = new XmlSerializer(typeof(T));
        return (T)serializer.Deserialize(new StringReader(xml));
      }
    }
