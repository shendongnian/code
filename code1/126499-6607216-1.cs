        public static IList<KeyValuePair<string, object>> ToList(this Enum enumObject)
        {
            Array Evalues = Enum.GetValues(enumObject.GetType());
            List<KeyValuePair<string, object>> list = new List<KeyValuePair<string, object>>();
            foreach (object value in Evalues)
            {
              list.Add(new KeyValuePair<string, object>(Enum.GetName(enumObject.GetType(), value), value));
            }
            return list;
