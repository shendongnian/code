    public static string ToJson<T>(/* this */ T value, Encoding encoding)
    {
        var serializer = new DataContractJsonSerializer(typeof(T));
        using (var stream = new MemoryStream())
        {
            using (var writer = JsonReaderWriterFactory.CreateJsonWriter(stream, encoding))
            {
                serializer.WriteObject(writer, value);
            }
            return encoding.GetString(stream.ToArray());
        }
    }
