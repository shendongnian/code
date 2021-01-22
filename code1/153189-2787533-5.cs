        public static string StringValue(this Enum enumItem) {
            return enumItem
                .GetType()
                .GetField(enumItem.ToString())
                .GetCustomAttributes<StringValueAttribute>()
                .Select(a => a.Value)
                .FirstOrDefault() ?? enumItem.ToString();
        }
