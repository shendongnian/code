    public static class StringHelpers
    {
        public static T ConvertStringToEnum<T>(string text)
        {
            T result;
            return Enum.TryParse(text, true, out result)
                && Enum.IsDefined(result.ToString())
                    ? result
                    : default(T);
        }
    }
