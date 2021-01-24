    class PurpleAirListConverter : JsonConverter
    {
        class PurpleAirDataDTO
        {
            // Required properties
            [JsonProperty("created_at")]
            public DateTime? CreatedAt { get; set; }
            [JsonProperty("Field8")]
            public double? AirQuality { get; set; }
            // Optional properties
            [JsonProperty("Field6")]
            public double? Temperature { get; set; }
            [JsonProperty("Field7")]
            public double? Humidity { get; set; }
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(List<PurpleAirData>);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.MoveToContent().TokenType == JsonToken.Null)
                return null;
            var list = existingValue as List<PurpleAirData> ?? new List<PurpleAirData>();
            var query = from dto in serializer.DeserializeArrayItems<PurpleAirDataDTO>(reader)
                        where dto != null && dto.CreatedAt != null && dto.AirQuality != null
                        select new PurpleAirData(dto.CreatedAt.Value, dto.AirQuality.Value) { Humidity = dto.Humidity, Temperature = dto.Temperature };
            list.AddRange(query);
            return list;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
