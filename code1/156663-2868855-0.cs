    public static void TransformIt(TextWriter output)
    {
        var inputDocument = XDocument.Parse(INPUT_XML);
        if (inputDocument.Root == null)
        {
            return;
        }
        
        var doc = new XDocument(
            new XElement(
                "responses",
                from response in inputDocument.Root.Elements()
                select new XElement(
                    "response",
                    from lv in GetResponseLabels(response)
                    select MakeResponse(lv.Label, lv.Value))));
        var settings = new XmlWriterSettings
        {
            Encoding = Encoding.UTF8,
            Indent = true,
        };
        using (var writer = XmlWriter.Create(output, settings))
        {
            if (writer == null)
            {
                return;
            }
            doc.WriteTo(writer);
        }
    }
    private static XElement MakeResponse(string label, string value)
    {
        var trimmedLabel = label.Replace(" ", String.Empty).Replace("?", String.Empty);
        return new XElement(trimmedLabel, value);
    }
    private static IEnumerable<LabelAndValue> GetResponseLabels(XContainer response)
    {
        var fieldsElement = response.Element("fields");
        if (fieldsElement == null)
        {
            return null;
        }
        return from field in fieldsElement.Elements("field")
               let valueElement = field.Element("value")
               let labelElement = field.Element("label")
               select new LabelAndValue
               {
                   Label = labelElement == null ? "Unknown" : labelElement.Value,
                   Value = valueElement == null ? null : valueElement.Value
               };
    }
    private struct LabelAndValue
    {
        public string Label { get; set; }
        public string Value { get; set; }
    }
