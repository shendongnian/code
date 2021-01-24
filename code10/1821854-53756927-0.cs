    class Equipment
    {
        public string Standard { get; set; }
        public string Name { get; set; }
        public int Efficiency { get; set; }
        public static Equipment FromLine(string line, string[] headers)
        {
            var data = line.Split(',');
            var ret = new Equipment();
            Type type = typeof(Equipment);
            for (int i = 0; i < headers.Length; ++i)
            {
                PropertyInfo property = type.GetProperty(headers[i]);
                property?.SetValue(ret, Convert.ChangeType(data[i], property.PropertyType));
            }
            return ret;
        }
    }
