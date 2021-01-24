    public class ConvertibleDictionaryConverter : JsonConverter
    {
        [JsonDictionary(ItemTypeNameHandling = TypeNameHandling.Auto)]
        class ConvertibleDictionaryDTO : Dictionary<string, ConvertibleWrapper>
        {
            public ConvertibleDictionaryDTO() : base() { }
            public ConvertibleDictionaryDTO(int count) : base(count) { }
        }
        public override bool CanConvert(Type objectType)
        {
            return typeof(IDictionary<string, IConvertible>).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var dto = serializer.Deserialize<ConvertibleDictionaryDTO>(reader);
            if (dto == null)
                return null;
            var dictionary = (IDictionary<string, IConvertible>)(existingValue ?? serializer.ContractResolver.ResolveContract(objectType).DefaultCreator());
            foreach (var pair in dto)
                dictionary.Add(pair.Key, pair.Value.ObjectValue);
            return dictionary;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var dictionary = (IDictionary<string, IConvertible>)value;
            var dto = new ConvertibleDictionaryDTO(dictionary.Count);
            foreach (var pair in dictionary)
                dto.Add(pair.Key, ConvertibleWrapper.CreateWrapper(pair.Value));
            serializer.Serialize(writer, dto);
        }
    }
    abstract class ConvertibleWrapper
    {
        protected ConvertibleWrapper() { }
        [JsonIgnore]
        public abstract IConvertible ObjectValue { get; }
        public static ConvertibleWrapper CreateWrapper<T>(T value) where T : IConvertible
        {
            if (value == null)
                return new ConvertibleWrapper<T>();
            var type = value.GetType();
            if (type == typeof(T))
                return new ConvertibleWrapper<T>(value);
            // Return actual type of subclass
            return (ConvertibleWrapper)Activator.CreateInstance(typeof(ConvertibleWrapper<>).MakeGenericType(type), value);
        }
    }
    sealed class ConvertibleWrapper<T> : ConvertibleWrapper where T : IConvertible
    {
        public ConvertibleWrapper() : base() { }
        public ConvertibleWrapper(T value)
            : base()
        {
            this.Value = value;
        }
        public override IConvertible ObjectValue { get { return Value; } }
        public T Value { get; set; }
    }
