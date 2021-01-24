    public class PropertyAsObjectConverter : JsonConverter
    {
       private readonly Type[] _types;
       public PropertyAsObjectConverter(params Type[] types)
       {
          _types = types;
       }
       public override bool CanConvert(Type objectType)
       {
          return _types.Any(t => t == objectType);
       }
       public override bool CanRead
       {
          get { return false; }
       }
       public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
       {
          throw new NotImplementedException();
       }
       public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
       {
          var properties = value.GetType().GetProperties(BindingFlags.Public|BindingFlags.Instance);
          foreach(var property in properties)
          {
             var name = property.Name;
             var attrs = property.GetCustomAttributes(typeof(JsonPropertyAttribute));
             if(attrs != null)
             {
                if (attrs.FirstOrDefault() is JsonPropertyAttribute attr)
                   name = attr.PropertyName;
             }
             writer.WriteStartObject();
             writer.WritePropertyName(name);
             serializer.Serialize(writer, property.GetValue(value));
             writer.WriteEndObject();
          }
       }
    }
