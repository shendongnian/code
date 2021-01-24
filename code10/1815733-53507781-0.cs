     class Program<T>
    {
       
      public static string langFilePath = @"..\..\..\Core\Data\Lang.json";
     public static JObject lang = JObject.Parse(File.ReadAllText(langFilePath));
        public static T GetJsonValue(string key)
        {
            T values = lang[key].ToObject<T>();
            return values;
        }
    }
