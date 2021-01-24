    internal class TranslationsToDictionaryObjectConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(List<CountryInfoModel>).IsAssignableFrom(objectType) 
                || typeof(List<CurrencyInfoModel>).IsAssignableFrom(objectType);
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            Dictionary<string, string> dict = new Dictionary<string, string>();
            try
            {
                foreach (var item in token)
                {
                    dict.Add(item["languageCode"].ToString(), item["translatedName"].ToString());
                }
            }
            catch
            {
                // ignored
            }
    
            return dict;
        }
    
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
        }
    }
