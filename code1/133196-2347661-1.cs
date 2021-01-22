        var serializer = new XmlSerializer(objectInstance.GetType());
        var sb = new StringBuilder();
        using (TextWriter writer = new StringWriter(sb))
        {
            serializer.Serialize(writer, objectInstance);
        }
        return sb.ToString();
    }
    public static T XmlDeserializeFromString<T>(string objectData)
    {
        return (T)XmlDeserializeFromString(objectData, typeof(T));
    }
    public static object XmlDeserializeFromString(string objectData, Type type)
    {
        var serializer = new XmlSerializer(type);
        object result;
        using (TextReader reader = new StringReader(objectData))
        {
            result = serializer.Deserialize(reader);
        }
        return result;
    }
