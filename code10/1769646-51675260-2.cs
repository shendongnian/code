        public static string DelimetedString(object obj)
        {
            var result = "";
            if (obj.GetType().IsValueType || obj is string)
                return obj.ToString();
            if (obj is IEnumerable)
            {
                foreach (var item in (IEnumerable)obj)
                {
                    result += DelimetedString(item) + ",";
                }
            }
            else
            {
                foreach (var prop in type.GetProperties())
                {
                    result += DelimetedString(prop.GetValue(obj)) + ",";
                }
            }
            return result.TrimEnd(',');
        }
