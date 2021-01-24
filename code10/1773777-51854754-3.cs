    class Program
        {
            //Get the logger object.
            private static readonly ILog logger = LogManager.GetLogger(typeof(Program));
    
            static void Main(string[] args)
            {
                try
                {
                    logger.Debug("Debug information.");
                    logger.Info("Info information.");
                    logger.Warn("Warn information.");
                    logger.Error("Error information.");
                    logger.Fatal("Fatal information.");
                    Console.WriteLine("ok");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadKey();
            }
        }
