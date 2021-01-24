    public class SnakeCaseConverter : JsonConverter {
      public override bool CanConvert(Type objectType) => objectType.GetCustomAttributes(true).OfType<SnakeCasedAttribute>().Any() == true;
      private static string ConvertFromSnakeCase(string snakeCased) {
        return string.Join("", snakeCased.Split('_').Select(part => part.Substring(0, 1).ToUpper() + part.Substring(1)));
      }
      public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
        var target = Activator.CreateInstance( objectType );
        var jobject = JObject.Load(reader);
        foreach (var property in jobject.Properties()) {
          var propName = ConvertFromSnakeCase(property.Name);
          var prop = objectType.GetProperty(propName);
          if (prop == null || !prop.CanWrite) {
            continue;
          }
          prop.SetValue(target, property.Value.ToObject(prop.PropertyType, serializer));
        }
        return target;
      }
      public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
        throw new NotImplementedException();
      }
    }
