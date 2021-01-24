    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        if (value is Student student)
        {
            student.Phone = MaskString(student.Phone);
        }
        Newtonsoft.Json.Linq.JToken t = Newtonsoft.Json.Linq.JToken.FromObject(value);
        t.WriteTo(writer);
    }
