    public interface IDebuggingService
    {
        bool RunningInDebugMode();
    }
    public class DebuggingService : IDebuggingService
    {
        private bool debugging;
        public bool RunningInDebugMode()
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
        private void WellAreWe()
        {
            debugging = true;
        }
    }
