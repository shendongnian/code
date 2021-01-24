    class Equipment
    {
        [DisplayName("STND,STANDARD,ST")]
        public string Standard { get; set; }
        [DisplayName("NAME")]
        public string Name { get; set; }
        [DisplayName("EFFICIENCY,EFFI")]
        public int Efficiency { get; set; }
        // You can add any other property
        public static Equipment FromLine(string line, string[] headers)
        {
            var data = line.Split(',');
            var ret = new Equipment();
            Type type = typeof(Equipment);
            foreach (PropertyInfo property in type.GetProperties())
            {
                var fieldNames = property.GetCustomAttribute<DisplayNameAttribute>()
                    .DisplayName.Split(',');
                for(int i = 0; i < headers.Length; ++i)
                {
                    if(fieldNames.Contains(headers[i]))
                    {
                        property.SetValue(ret, Convert.ChangeType(data[i], property.PropertyType));
                        break;
                    }
                }
                
            }
            return ret;
        }
    }
