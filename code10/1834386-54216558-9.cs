    List<RootObject> dataObjects = new List<RootObject>();
    using (StreamReader sr = new StreamReader(stream))
    {
        var JSONObject = sr.ReadToEnd();
        var reader = new JsonTextReader(new StringReader(JSONObject)) { SupportMultipleContent = true };
        var serializer = new JsonSerializer();
        while (reader.Read()) {
            dataObjects.Add(serializer.Deserialize<RootObject>(reader));
        }
        reader.Close();
    }
