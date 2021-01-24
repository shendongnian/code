    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        Newtonsoft.Json.Linq.JToken t = Newtonsoft.Json.Linq.JToken.FromObject(value);
        JObject jo = (JObject)t;
        if (value is Student)
        {
            jo["Phone"] = MaskString(jo.Value<string>("Phone"));
            if (String.IsNullOrEmpty(jo.Value<string>("Name")))
            {
                jo.Remove("Name");
            }
        }
        serializer.Serialize(writer, jo, typeof(Student));
    }
