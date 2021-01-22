        public static List<PropertyInfo> GetDifferences(Employee test1, Employee test2)
        {
            List<PropertyInfo> differences = new List<PropertyInfo>();
            foreach (PropertyInfo property in test1.GetType().GetProperties())
            {
                object value1 = property.GetValue(test1, null);
                object value2 = property.GetValue(test2, null);
                if (!value1.Equals(value2))
                {
                    differences.Add(property);
                }
            }
            return differences;
        }
