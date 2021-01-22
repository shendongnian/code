    public static class IntHelper
    {
        public static bool TryParse(string s, ref int outValue)
        {
            int newValue;
            bool ret = int.TryParse(s, out newValue);
            if (ret) outValue = newValue;
            return ret;
        }
    }
