        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JToken t = JToken.FromObject((MyBase)value);
            JObject jo = (JObject)t;
            var baseProperties = 
          typeof(MyBase).GetProperties(System.Reflection.BindingFlags.Public
           | System.Reflection.BindingFlags.Instance
           | System.Reflection.BindingFlags.DeclaredOnly);
            var derivedProperties = 
     typeof(MyDerived).GetProperties(System.Reflection.BindingFlags.Public
     | System.Reflection.BindingFlags.Instance
     | System.Reflection.BindingFlags.DeclaredOnly);
          var derivedValues =   jo.Properties().Where(x => derivedProperties.Any(y => y.Name == x.Name));
            var baseValues = jo.Properties().Where(x => baseProperties.Any(y => y.Name == x.Name)).ToList();
            JObject o = new JObject(baseValues);
            o.Add(new JProperty("properties", new JObject(derivedValues)));
            o.WriteTo(writer);
            
        }
