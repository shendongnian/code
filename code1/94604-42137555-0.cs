     public static string Serialize<T>(this T value) {
            if (value == null) {
                return string.Empty;
            }
            try {
                var xmlserializer = new XmlSerializer(typeof(T));
                var stringWriter = new Utf8StringWriter();
                using (var writer = XmlWriter.Create(stringWriter)) {
                    xmlserializer.Serialize(writer, value);
                    return stringWriter.ToString();
                }
            } catch (Exception ex) {
                throw new Exception("An error occurred", ex);
            }
        }
