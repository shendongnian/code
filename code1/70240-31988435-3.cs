    public class EnumExtention
    {
        public Dictionary<int, string> ToDictionary(Enum myEnum)
        {
            var myEnumType = myEnum.GetType();
            var names = myEnumType.GetFields()
                .Where(m => m.GetCustomAttribute<DisplayAttribute>() != null)
                .Select(e => e.GetCustomAttribute<DisplayAttribute>().Name);
            var values = Enum.GetValues(myEnumType).Cast<int>();
            return names.Zip(values, (n, v) => new KeyValuePair<int, string>(v, n))
                .ToDictionary(kv => kv.Key, kv => kv.Value);
        }
    }
