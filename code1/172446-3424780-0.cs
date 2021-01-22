    /// <summary>
    /// Converts this instance to XML.
    /// </summary>
    /// <returns>XML representing this instance.</returns>
    public string ToXml()
    {
        var serializer = new DataContractSerializer(this.GetType());
        var output = new StringWriter();
        using (var writer = new XmlTextWriter(output) { Formatting = Formatting.Indented })
        {
            serializer.WriteObject(writer, this);
        }
        return output.GetStringBuilder().ToString();
    }
