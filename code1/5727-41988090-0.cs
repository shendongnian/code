    public static class CloneThroughJsonExtension
    {
        private static readonly JsonSerializerSettings DeserializeSettings = new JsonSerializerSettings { ObjectCreationHandling = ObjectCreationHandling.Replace };
        public static T CloneThroughJson<T>(this T source)
        {
            return ReferenceEquals(source, null) ? default(T) : JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(source), DeserializeSettings);
        }
    }
