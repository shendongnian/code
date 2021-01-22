    using System.Text.RegularExpression;
    public static class AnExtension
    {
        public static string Name(this Enum value)
        {
            string strVal = value.ToString();
            try
            {
                return Regex.Replace(strVal, "([a-z])([A-Z])", "$1 $2");
            }
            catch
            {
            }
            return strVal;
        }
    }
