    public static class MessageExtensions
    {
        public static T Deserialize<T>(this string message) where T : Message
        {
            T instance = Activator.CreateInstance<T>();
            instance.Original = message;
            JsonConvert.PopulateObject(message, instance);
            return instance;
        }
    }
