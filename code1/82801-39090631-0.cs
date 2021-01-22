    internal class Helper
    {
        internal static bool IsDebugBuild
        {
            get
            {
    #if DEBUG
                return true;
    #endif
                return false;
            }
        }
    }
