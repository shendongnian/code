    public class VarArgsConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var obj = (JObject)JToken.FromObject(value);
            var objTitle = new JObject();
            objTitle.Add("title", obj.GetValue("title"));
            var objOwner = new JObject();
            objOwner.Add("owner", obj.GetValue("owner"));
            objTitle.WriteTo(writer);
            objOwner.WriteTo(writer);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException("Unnecessary because CanRead is false. The type will skip the converter.");
        }
        public override bool CanRead
        {
            get { return false; }
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Var_Args);
        }
    }
    public class Wrapper
    {
        [JsonProperty("requests")]
        public Request Requests { get; set; }
    }
    public class Request
    {
        public Var_Args[] var_args { get; set; }
    }
    public class Var_Args
    {
        public object title { get; set; }
        public object owner { get; set; }
    }
