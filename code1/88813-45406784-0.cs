        public static T GetEnum<T>(string s)
        {
            Array arr = Enum.GetValues(typeof(T));
            foreach (var x in arr)
            {
                if (x.ToString().Contains(s))
                    return (T)x;
            }
            return default(T);
        }
