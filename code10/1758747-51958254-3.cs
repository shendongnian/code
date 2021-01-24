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
  public class JConvert {
    public static string ToJson(object obj, JsonSerializerSettings settings = null) =>
      settings is null ? JsonConvert.SerializeObject(obj) : JsonConvert.SerializeObject(obj, settings);
    public static T FromJson<T>(string json, JsonSerializerSettings settings = null) =>
      JsonConvert.DeserializeObject<T>(json, settings);
  }
}
and use `JConvert.ToJson(obj)` and `JConvert<T>.FromJson(json)` as shortcuts
