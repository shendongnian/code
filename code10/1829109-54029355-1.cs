    class BaseClassConverter : JsonCreationConverter<BaseClass>
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // Implement this if you need to serialize the object too
            throw new NotImplementedException();
        }
        protected override BaseClass Create(Type objectType, JObject jObject)
        {
            if (jObject["type"].Value<string>() == "a")
            {
                return new A();
            }
            else
            {
                return new B();
            }
        }
    }
    public abstract class JsonCreationConverter<T> : JsonConverter
    {
        /// <summary>
        /// Create an instance of objectType, based properties in the JSON object
        /// </summary>
        /// <param name="objectType">type of object expected</param>
        /// <param name="jObject">
        /// contents of JSON object that will be deserialized
        /// </param>
        /// <returns></returns>
        protected abstract T Create(Type objectType, JObject jObject);
        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }
        public override bool CanWrite
        {
            get { return false; }
        }
        public override object ReadJson(JsonReader reader,
                                        Type objectType,
                                         object existingValue,
                                         JsonSerializer serializer)
        {
            // Load JObject from stream
            JObject jObject = JObject.Load(reader);
            // Create target object based on JObject
            T target = Create(objectType, jObject);
            // Populate the object properties
            serializer.Populate(jObject.CreateReader(), target);
            return target;
        }
    }
