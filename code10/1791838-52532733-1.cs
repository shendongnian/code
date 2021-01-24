    class Program
    {
        static void Main(string[] args)
        {
               System.AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionTrapper;
            try
            {
                // do some work
            }
            catch(Exception ex)
            {
                // write output to log file
            }
        }
        static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e) {
          // handle the expception
        }
      }
