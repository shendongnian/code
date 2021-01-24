    internal class Program
    {
        private static readonly Logger DefaultLogger = LogManager.GetLogger("default");
        private static readonly Logger OtherLogger = LogManager.GetLogger("other");
        private static void Main(string[] args)
        {
            for (var i = 0; i < 2; i++)
            {
                if (i % 2 == 0)
                {
                    DefaultLogger.Info("normal log message");
                }
                else
                {
                    OtherLogger.Info("special case");
                }
            }
        }
    }
