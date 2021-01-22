    class Sample
    {
        private static readonly log4net.ILog LOG;
        static Sample()
        {
            if (log4net.LogManager.GetCurrentLoggers().Count() == 0)
            {
                loadConfig();
            }
            LOG = log4net.LogManager.GetLogger(typeof(Sample));
        }
        private static void loadConfig()
        {
            /* Load your config file here */
        }
        public void YourMethod()
        {
           LOG.Info("Your messages");
        }
    }
