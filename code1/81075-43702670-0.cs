    public static class Logger
    {
        private static Action<string, Exception> _logError;
        public static bool Initialised;
    
        public static void InitLogger(Action<string, Exception, bool> logError)
        {
            if(logError == null) return;
            _logError = logError
            Initialised = true;
        }
    
        public static void LogError(string msg, Exception e = null)
        {
            if (_logError != null)
            {
                try
                {
                    _logError.Invoke(msg, e);
                }
                catch (Exception){}
            }
            else
            {
                Debug.WriteLine($"LogError() Msg: {msg} Exception: {e}");
            }
        }
    }
    
    public class MainViewModel
    {
        public MainViewModel()
        {
            //Inject the logger so we can call it globally from anywhere in the project
            Logger.InitLogger(LogError);
        }
        public void LogError(string msg, Exception e = null)
        {
            //Implementation of logger
    	}
    }
