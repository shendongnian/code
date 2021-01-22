    public static class ApplicationState 
    { 
        private static Dictionary<string, object> _values =
                   new Dictionary<string, object>();
        
        public static void SetValue(string key, object value) 
        {
            _values.Add(key, value);
        }
        public static T GetValue<T>(string value) 
        {
            return (T)_values["value"];
        }
    }
