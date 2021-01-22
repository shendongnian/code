    public void MyFunction(params KeyValuePair<string, object>[] pairs)
    {
        // ...
    }
    public static class Pairing
    {
        public static KeyValuePair<string, object> Of(string key, object value)
        {
            return new KeyValuePair<string, object>(key, value);
        }
    }
