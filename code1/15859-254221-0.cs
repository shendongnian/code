    public static class MyHelper
    {
        public static V GetValueOrDefault<K, V>(this Dictionary<K, V> dic, K key, V defaultVal)
        {
            V ret;
            bool found = dic.TryGetValue(key, out ret);
            if (found) { return ret; }
            return defaultVal;
        }
        void Example()
        {
            var dict = new Dictionary<int, string>();
            dict.GetValueOrDefault(42, "default");
        }
    }
