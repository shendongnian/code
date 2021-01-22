    static class Program
    {
        public static bool IsDebugRelease
        {
            get
            {
     #if DEBUG
                return true;
     #else
                return false;
     #endif
            }
         }
     }
