    [JsonConverter(typeof(AccountIdConverter))]
    public readonly struct AccountId
    {
        public Guid Value { get; }
        // ... 
    }
    public class AccountIdConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
            => objectType == typeof(AccountId);
        // this converter is only used for serialization, not to deserialize
        public override bool CanRead => false;
        // implement this if you need to read the string representation to create an AccountId
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            => throw new NotImplementedException();
        
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (!(value is AccountId accountId))
                throw new JsonSerializationException("Expected AccountId object value.");
            // custom response 
            writer.WriteValue(accountId.Value);
        }
    }
