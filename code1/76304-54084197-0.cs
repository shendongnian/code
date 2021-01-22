    public static class Props
    {
        public static string PropName()
        {
            return (new StackTrace()).GetFrame(1).GetMethod().Name.Replace("set_", "").Replace("get_", "");
        }
        public static string MethodName()
        {
            return (new StackTrace()).GetFrame(1).GetMethod().Name;
        }
    }
