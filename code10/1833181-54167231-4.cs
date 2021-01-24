    public static class EnumHelper
    {
        public static HtmlString EnumToString<T>()
        {
            var values = Enum.GetValues(typeof(T)).Cast<int>();
            var enumDictionary = values.ToDictionary(value => Enum.GetName(typeof(T), value));
            return new HtmlString(JsonConvert.SerializeObject(enumDictionary));
        }
    }
