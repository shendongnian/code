    using (var f = new StreamReader("json1.json"))
    {
        string json = f.ReadToEnd();
        dynamic deserializedObject = JsonConvert.DeserializeObject<ExpandoObject>(json);
        Console.WriteLine(deserializesObject.errors.error1.name);
    }
