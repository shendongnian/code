    public class Program
        {
            private static readonly log4net.ILog log
          = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            static void Main(string[] args)
            {
                XmlConfigurator.Configure(new FileInfo("..\\..\\log4net.config"));
                log.Debug("Hi this is DEBUG from logging");
                log.Info("This is information from logger");
                log.Error("This is Error from logger");
                Console.ReadLine();
    
            }
        }
