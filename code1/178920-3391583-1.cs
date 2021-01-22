    public static class Colors
    {
        private static readonly Dictionary<string, Color> dictionary =
            typeof(Color).GetProperties(BindingFlags.Public | 
                                        BindingFlags.Static)
                         .Where(prop => prop.PropertyType == typeof(Color))
                         .ToDictionary(prop => prop.Name,
                                       prop => (Color) prop.GetValue(null, null)));
        public static Color FromName(string name)
        {
            // Adjust behaviour for lookup failure etc
            return dictionary[name];
        }
    }
