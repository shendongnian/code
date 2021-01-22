    public static string GetString(string key)
        {
            string s = Get<string>(key);
            return s == null ? string.Empty : s;
        }
        public static void SetString(string key, string value)
        {
            Set<string>(key, value);
        }
