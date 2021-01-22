        public static T GetPropertyValue<T>(string propertyIdCode)
        {
            if (propertyIdCode == "firstName")
                return (T)(object)"Jim";
            if (propertyIdCode == "age")
                return (T)(object)32;
            return default(T);
        }
