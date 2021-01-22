    namespace My.Library
        public static class Class
        {
            static string className = MethodBase.GetCurrentMethod().DeclaringType.FullName;
            public static string GetName()
            {
                 return className;
            }
        }
    }
    
