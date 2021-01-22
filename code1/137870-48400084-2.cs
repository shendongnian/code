            public static T KeyByValue<T, W>(this Dictionary<T, W> dict, T val)
        {
            T key = default;
            foreach (KeyValuePair<T, W> pair in dict)
            {
                if (pair.Value.Equals(val))
                {
                    key = pair.Key;
                    break;
                }
            }
            return key;
        }
