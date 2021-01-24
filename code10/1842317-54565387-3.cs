    public class CustomJsonConverter : Newtonsoft.Json.JsonConverter
    {
        [ThreadStatic]
        static bool disabled;
        // Disables the converter in a thread-safe manner.
        bool Disabled { get { return disabled; } set { disabled = value; } }
        public override bool CanWrite { get { return !Disabled; } }
        public override bool CanRead { get { return !Disabled; } }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            using (new PushValue<bool>(true, () => Disabled, val => Disabled = val))
            using (new PushValue<PreserveReferencesHandling>(PreserveReferencesHandling.Objects, () => serializer.PreserveReferencesHandling, val => serializer.PreserveReferencesHandling = val))
            using (new PushValue<DefaultValueHandling>(DefaultValueHandling.Ignore, () => serializer.DefaultValueHandling, val => serializer.DefaultValueHandling = val))
            using (new PushValue<NullValueHandling>(NullValueHandling.Ignore, () => serializer.NullValueHandling, val => serializer.NullValueHandling = val))
            {
                serializer.Serialize(writer, value);
            }
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }
            using (new PushValue<bool>(true, () => Disabled, val => Disabled = val))
            using (new PushValue<PreserveReferencesHandling>(PreserveReferencesHandling.Objects, () => serializer.PreserveReferencesHandling, val => serializer.PreserveReferencesHandling = val))
            using (new PushValue<DefaultValueHandling>(DefaultValueHandling.Ignore, () => serializer.DefaultValueHandling, val => serializer.DefaultValueHandling = val))
            using (new PushValue<NullValueHandling>(NullValueHandling.Ignore, () => serializer.NullValueHandling, val => serializer.NullValueHandling = val))
            {
                return serializer.Deserialize(reader, objectType);
            }
        }
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
    }
    public struct PushValue<T> : IDisposable
    {
        Action<T> setValue;
        T oldValue;
        public PushValue(T value, Func<T> getValue, Action<T> setValue)
        {
            if (getValue == null || setValue == null)
                throw new ArgumentNullException();
            this.setValue = setValue;
            this.oldValue = getValue();
            setValue(value);
        }
        // By using a disposable struct we avoid the overhead of allocating and freeing an instance of a finalizable class.
        public void Dispose()
        {
            if (setValue != null)
                setValue(oldValue);
        }
    }
