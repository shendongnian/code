    try
    {
        File.WriteAllText("rce-test.txt", "");
        var badJson = JToken.FromObject(
            new
            {
                Models = new object[] 
                {
                    new FileInfo("rce-test.txt") { IsReadOnly = false },
                }
            },
            JsonSerializer.CreateDefault(new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, Formatting = Formatting.Indented }));
        ((JObject)badJson["Models"][0])["IsReadOnly"] = true;
        Console.WriteLine("Attempting to deserialize attack JSON: ");
        Console.WriteLine(badJson);
        var dto2 = JsonConvert.DeserializeObject<ModelBaseCollectionDTO>(badJson.ToString());
        Assert.IsTrue(false, "should not come here");
    }
    catch (JsonException ex)
    {
        Assert.IsTrue(!new FileInfo("rce-test.txt").IsReadOnly);
        Console.WriteLine("Caught expected {0}: {1}", ex.GetType(), ex.Message);
    }
