    public static class AppCompilationConfiguration
    {
        private static bool debugMode;
        private static bool IsDebugMode()
        {
            SetDebugMode();
            return debugMode;
        }
        //This method will be loaded only in the case of DEBUG mode. 
        //In RELEASE mode, all the calls to this method will be ignored by runtime.
        [Conditional("DEBUG")]
        private static void SetDebugMode()
        {
            debugMode = true;
        }
        public static string CompilationMode => IsDebugMode() ? "DEBUG" : "RELEASE";
    }
