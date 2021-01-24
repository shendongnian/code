    public static class EnumList
    {
        public static IEnumerable<KeyValuePair<T, string>> GetDescriptions<T>()
        {
            return Enum.GetValues(typeof(T))
                .Cast<T>()
                .Select(p => new KeyValuePair<T, string>(
                    p,                   
                    (p.GetType().GetField(p.ToString())
                    .GetCustomAttributes(typeof(DescriptionAttribute), false)
                    .FirstOrDefault() as DescriptionAttribute)?.Description ?? ""
                    ))
                    .ToList();
        }
    }
