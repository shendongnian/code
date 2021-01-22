    namespace ExtensionMethods
    {
        public static class MyExtensionMethods
        {
            public static DateTime Tomorrow(this DateTime date)
            {
               return date.AddDays(1);
            }    
        }
    }
