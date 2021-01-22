            public static Dictionary<string, string> ToDictionary<T>(List<T> list, string keyName, string valueName)
        {
            Dictionary<string, string> outputDictionary = new Dictionary<string, string>();
            foreach (T item in list)
            {
                string key = Eval<T, string>(item, keyName);
                string value = Eval<T, string>(item, valueName);
                output[key] = value;
            }
            return outputDictionary;
        }
        public static TOut Eval<TIn, TOut>(TIn source, string propertyName)
        {
            object o = DataBinder.GetPropertyValue(source, propertyName);
            if (o is TOut)
                return (TOut)o;
            return default(TOut);
        }
