    var originalExpr = EditableExpression.CreateEditableExpression<string, bool>(
        str => str.Length > 3);
    var serializer = new XmlSerializer(originalExpr.GetType());
    string xml;
    using (var writer = new StringWriter())
    {
        serializer.Serialize(writer, originalExpr);
        xml = writer.ToString();
    }
