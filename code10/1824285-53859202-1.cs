    public class Program
    {
        public static void Main(string[] args)
        {
            CurrentDirectoryHelpers.SetCurrentDirectory();
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information() // Set the minimun log level
                .WriteTo.File("Logs\\log-.txt", rollingInterval: RollingInterval.Day, retainedFileCountLimit: 7) // this is for logging into file system
                .CreateLogger();
            ...
        }
    }
