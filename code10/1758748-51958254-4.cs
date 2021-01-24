namespace Newtonsoft.Json {
  class JsonManualConverter : JsonConverter {
    public override bool CanConvert(Type t) => t.GetMethod("ToJson") != null && t.GetMethod("FromJson") != null;
    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) =>
      objectType.GetMethod("FromJson").Invoke(new object(), new object[] { JRaw.Create(reader).ToString() });
    public override void WriteJson(JsonWriter writer, object o, JsonSerializer serializer) =>
      writer.WriteRaw(o.GetType().GetMethod("ToJson").Invoke(o, new object[] { }) as string);
  }
}
Then we can simply do:
  [JsonConverter(typeof(JsonManualConverter))]
  class MyClass {
    public string ToJson() => // serialize and return json string
    static public MyClass FromJson(string json) => // deserialize and return a MyClass instance
    ...
  }
and Json.Net will use these methods
I also found it useful to create:
namespace Newtonsoft.Json {
    public static string ToJson(object value) => JsonConvert.SerializeObject(value);
    public static string ToJson(object value, Formatting formatting) => JsonConvert.SerializeObject(value, formatting);
    public static string ToJson(object value, params JsonConverter[] converters) => JsonConvert.SerializeObject(value, converters);
    public static string ToJson(object value, Formatting formatting, params JsonConverter[] converters) => JsonConvert.SerializeObject(value, formatting, converters);
    public static string ToJson(object value, JsonSerializerSettings settings) => JsonConvert.SerializeObject(value, settings);
    public static string ToJson(object value, Type type, JsonSerializerSettings settings) => JsonConvert.SerializeObject(value, type, settings);
    public static string ToJson(object value, Formatting formatting, JsonSerializerSettings settings) => JsonConvert.SerializeObject(value, formatting, settings);
    public static string ToJson(object value, Type type, Formatting formatting, JsonSerializerSettings settings) => JsonConvert.SerializeObject(value, type, formatting, settings);
    public static T FromJson<T>(string value) => JsonConvert.DeserializeObject<T>(value);
    public static T FromJson<T>(string value, params JsonConverter[] converters) => JsonConvert.DeserializeObject<T>(value, converters);
    public static T FromJson<T>(string value, JsonSerializerSettings settings) => JsonConvert.DeserializeObject<T>(value, settings);
}
and use `JConvert.ToJson(obj)` and `JConvert<T>.FromJson(json)` as shortcuts
