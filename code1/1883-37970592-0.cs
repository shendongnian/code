        private static Dictionary<Type, Dictionary<string, object>> dicEnum = new Dictionary<Type, Dictionary<string, object>>();
        public static T ToEnum<T>(this string value, T defaultValue)
        {
            var t = typeof(T);
            Dictionary<string, object> dic;
            if (!dicEnum.ContainsKey(t))
            {
                dic = new Dictionary<string, object>();
                dicEnum.Add(t, dic);
                foreach (var en in Enum.GetValues(t))
                    dic.Add(en.ToString(), en);
            }
            else
                dic = dicEnum[t];
            if (!dic.ContainsKey(value))
                return defaultValue;
            else
                return (T)dic[value];
        }
