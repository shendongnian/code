    namespace System {
      public static class ExtensionsMethods {
        public static string ToJson(this object obj, JsonSerializerSettings settings=null) => 
          settings is null ? JsonConvert.SerializeObject(obj) : JsonConvert.SerializeObject(obj, settings);
        public static T FromJson<T>(this object obj, string json, JsonSerializerSettings settings = null) => 
          JsonConvert.DeserializeObject<T>(json, settings);
      }
    }
