    public static class Props
    {
        public static string GetCallerName([System.Runtime.CompilerServices.CallerMemberName] String propertyName = "")
        {
             return propertyName;
        }
    }
