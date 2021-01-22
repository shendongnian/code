    public static class Common {
        public static bool Equals<T>(params T[] args)
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
    if (Common.Equals<int>(a, b, c, d, e, f, g)) 
