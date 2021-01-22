    public class AppLogger
    {
       public void WriteLine(String format, params object[] args)
        {
            if ( LoggingEnabled )
            {
                Console.WriteLine( format, args );
            }
        }
    }
