    public class Program
    {
        public static void Main(string[] args)
        {
            CurrentDirectoryHelpers.SetCurrentDirectory();
    
            Log.Logger = new LoggerConfiguration()
                    .Enrich.FromLogContext()
                    .ReadFrom.Configuration(Configuration)
                    .WriteTo.Console()
                    .CreateLogger();
    
            ...
        }
    }
