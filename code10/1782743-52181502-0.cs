    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        List<Author> list = value as List<Author>;
        int count = list?.Count ?? 0;
        JToken t;
        // count > 1 ?
        if (count >= 1)
        {
            t = JToken.FromObject(list[0]);
        }
        else
        {
            t = JToken.FromObject(new List<Author>());
        }
        t.WriteTo(writer);
    }
