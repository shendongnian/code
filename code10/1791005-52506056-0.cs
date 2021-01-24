    public static class ExtendBaseApiModel
    {
        public static string ToJson(this T obj) { /* ... */ }
        public static T FromJson<T>(this T obj, string json) where T : BaseApiModel { /* ... */ }
    }
