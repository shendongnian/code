    public static string ToXml<T>(this T obj) where T : class
    {
        XmlSerializer s = new XmlSerializer(obj.GetType());
        using (StringWriter writer = new StringWriter())
        {
            s.Serialize(writer, obj);
            return writer.ToString();
        }
    }
    "<root><child>foo</child</root>".ToXml<MyCustomType>();
