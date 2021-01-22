    public static class Common {
        public static bool AllAreEqual<T>(params T[] args)
        {
            if (args != null && args.Length > 1)
            {
                for (int i = 1; i < args.Length; i++)
                {
                    if (args[i] != args[i - 1]) return false;
                }
            }
    
            return true;
        } 
    }
    ...
    if (Common.AllAreEqual<int>(a, b, c, d, e, f, g)) 
