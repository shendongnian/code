    public static class Props
    {
        public static string CurrPropName => 
             (new StackTrace()).GetFrame(1).GetMethod().Name.Replace("set_", "").Replace("get_", "");
    
        public static string CurrMethodName => 
            (new StackTrace()).GetFrame(1).GetMethod().Name;
    }
