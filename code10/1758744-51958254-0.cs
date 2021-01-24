    namespace System {
      public static class ExtensionsMethods {
        public static string ToJson(this object obj) => JsonConvert.SerializeObject(obj);
        public static T FromJson<T>(this object obj, string json) => JsonConvert.DeserializeObject<T>(json);
      }
    }
