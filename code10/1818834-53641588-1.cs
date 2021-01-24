    public class TransHelperConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var transHelperInst = value as TransHelper;
        
            if(transHelperInst is null)
                 throw new ArgumentException();
        
            var property = new JProperty(transHelperInst.Key, transHelperInst.Translation);
            property.WriteTo(writer);
       }
        
       public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
       {
           throw new NotImplementedException("Unnecessary because CanRead is false. The type will skip the converter.");
       }
        
      public override bool CanRead => false;
        
      public override bool CanConvert(Type objectType)
      {
          return objectType == typeof(TransHelper);
      }
    }
