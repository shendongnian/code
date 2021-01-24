    public string Convert(string country)
        {
            string result = string.Empty;
            FieldInfo fieldInfo = GetType().GetField(country);
            result = fieldInfo?.GetValue(this)?.ToString();
            return result;
        }
