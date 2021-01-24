    public static class EnumerableToCsvExtension
    {
        public static string ToCSVString<TContent>(this IEnumerable<TContent> enumerable, char propertySeparator = ',', bool includeHeader = true)
        {
            var properties = typeof(TContent).GetProperties(BindingFlags.Instance | BindingFlags.Public);
            var header = string.Join(propertySeparator, properties.Select(p => p.Name));
            var rows = enumerable.ToList().ConvertAll(item => string.Join(propertySeparator, properties.Select(p => p.GetValue(item) ?? string.Empty )));
            var csvArray = includeHeader ? rows.Prepend(header) : rows;
            return string.Join(Environment.NewLine, csvArray);
        }
    }
