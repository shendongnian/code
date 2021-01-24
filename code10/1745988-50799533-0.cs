    public static bool ContainsValue(this string str, string value)
        {
            bool rs = false;
            if (str != null && value != null)
                rs = str.ToUpper().Contains(value.ToUpper());
            return rs;
        }
