    public class TransHelperConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var transHelperInst = value as TransHelper;
        
            if(transHelperInst is null)
                 throw new ArgumentException();
        
            //  Creates the Json property. 
                var property = new JProperty(transHelperInst.Key, transHelperInst.Translation);
            //  Adds it the Json object.
            var transHelperObject = new JObject();
            transHelperObject.AddFirst(property);
            //  Writes the object.
            transHelperObject.WriteTo(writer);
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
