    static class Log4NetHelper
    {
        private static bool _isConfigured;
        static void EnsureConfigured()
        {
            if (!_isConfigured)
            {
                ... configure log4net here ...
                _isConfigured = true;
            }
        }
        static ILog GetLogger(string name)
        {
            EnsureConfigured();
            log4net.ILog logger = log4net.LogManager.GetLogger(name);
        }
    }
