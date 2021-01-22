    class Foo
    {
        public static string ClassName
        {
            get
            {
                return MethodBase.GetCurrentMethod().DeclaringType.Name;
            }
        }
    }
