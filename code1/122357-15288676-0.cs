    public interface IDebuggingService
    {
        bool RunningInDebugMode();
    }
    public class DebuggingService : IDebuggingService
    {
        public bool RunningInDebugMode()
        {
            return Debugging.RunningInDebugMode();
        }
    }
    public static class Debugging
    {
        private static bool debugging;
        public static bool RunningInDebugMode()
        {
            //#if DEBUG
            //return true;
            //#else
            //return false;
            //#endif
            WellAreWe();
            return debugging;
        }
        [Conditional("DEBUG")]
        private static void WellAreWe()
        {
            debugging = true;
        }
    }
