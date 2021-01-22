    public static class ExtensionMethods
    {
        public static int IntValue(this Enum argEnum)
        {
            return Convert.ToInt32(argEnum);
        }
    }
