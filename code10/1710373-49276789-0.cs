    public static class ObjectExtensions
    {
        public static T Clone<T>(this T obj)
        {
            return (T)JsonConvert.DeserializeObject(JsonConvert.SerializeObject(obj));
        }
    }
