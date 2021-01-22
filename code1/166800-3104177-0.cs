    private static string SerializeResponse(Response response)
    {
        var output = new StringWriter();
        var writer = XmlWriter.Create(output);
        new XmlSerializer(typeof(Response)).Serialize(writer, response);
        return output.ToString();
    }
