    public class EnumHelper
    {
        public static T? TryParse<T>(string text)
            where T: struct
        {
            if (string.IsNullOrEmpty(text))
            {
                return null;
            }
            T r;
            if (Enum.TryParse<T>(text, out r))
            {
                return r;
            }
            return null;
        }
    }
