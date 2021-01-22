    public static class My.Library.Class
    {
        string className = MethodBase.GetCurrentMethod().DeclaringType.FullName;
        public static string GetName()
        {
             return className;
        }
    }
