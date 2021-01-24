    class Equipment
    {
        [DisplayName("STND, STANDARD, ST")]
        public string Standard { get; set; }
        [DisplayName("NAME")]
        public string Name { get; set; }
        [DisplayName("EFFICIENCY, EFFI")]
        public int Efficiency { get; set; }
        // You can add any other property
        public static Equipment FromLine(string line, Dictionary<PropertyInfo, int> map)
        {
            var data = line.Split(',').Select(t => t.Trim()).ToArray();
            var ret = new Equipment();
            Type type = typeof(Equipment);
            foreach (PropertyInfo property in type.GetProperties())
            {
                int index = map[property];
                property.SetValue(ret, Convert.ChangeType(data[index],
                    property.PropertyType));
            }
            return ret;
        }
        public static Dictionary<PropertyInfo, int> GetIndexes(string headers)
        {
            var headerArray = headers.Split(',').Select(t => t.Trim()).ToArray();
            Type type = typeof(Equipment);
            var ret = new Dictionary<PropertyInfo, int>();
            foreach (PropertyInfo property in type.GetProperties())
            {
                var fieldNames = property.GetCustomAttribute<DisplayNameAttribute>()
                    .DisplayName.Split(',').Select(t => t.Trim()).ToArray();
                for (int i = 0; i < headerArray.Length; ++i)
                {
                    if (!fieldNames.Contains(headerArray[i])) continue;
                    ret[property] = i;
                    break;
                }
            }
            return ret;
        }
    }
