    class Program
        {
            static void Main(string[] args)
            {
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
                throw new StackOverflowException();
            }
    
            // We trap this, we can't save the process, 
            // but we can prevent the "ILLEGAL OPERATION" window 
            static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
            {
                if (e.IsTerminating)
                {
                    Environment.Exit(1);
                }
            }
        }
