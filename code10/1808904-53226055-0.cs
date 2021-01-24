    public class Model
    {
        // other properties here 
        // ....
        [JsonIgnore]
        public string Mercadoria => GetValue("Mercadoria");
        [JsonIgnore]
        public string Descarga => GetValue("Descarga");
        public JObject MercadoriasPresencaCarga { get; set; }
        private string GetValue(string path)
        {
            if (MercadoriasPresencaCarga == null)
            {
                return null;
            }
            string value = null;
            JToken token = MercadoriasPresencaCarga.SelectToken(path);
            if (token.Type == JTokenType.Array && token.HasValues)
            {
                value = token.First.Value<string>();
            }
            else
            {
                value = token.Value<string>();
            }
            return value;
        }
    }
