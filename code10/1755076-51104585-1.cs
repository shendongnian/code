    class UserListConverter<T> : JsonConverter where T: IHasUsers, new()
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(IHasUsers).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JArray array = JArray.Load(reader);
            T obj = new T() { Users = array.ToObject<User[]>() };
            return obj;
        }
        public override bool CanWrite
        {
            get { return false; }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
