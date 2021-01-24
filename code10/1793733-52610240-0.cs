    public static string Base64Decode(string base64EncodedData)
    {
        var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
        using (var reader = new StreamReader(new MemoryStream(base64EncodedBytes), true))
        {
            return reader.ReadToEnd();
        }
    }
