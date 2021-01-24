    using Newtonsoft.Json;
    public static class ObjectExtensions
    {
        public static T Clone<T>(this T source)
        {
            var serialized = JsonConvert.SerializeObject(source);
            var clone = JsonConvert.DeserializeObject<T>(serialized);
            return clone;
        }
    }
