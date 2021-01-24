    internal class Program
    {
        private static int Main(string[] args)
        {
          var container = CreateContainer();
          var worker = container.resolve<IWorker>();
          worker.Execute();
        }
    }
    internal class Worker : IWorker
    {
        private IConfiguration _configuration;
        private IFileSystem _filesystem;
        private ILog _log;
        private IDateTimeFactory _datetimeFactory;
        public Worker(
          IConfiguration configuration,
          IFileSystem filesystem,
          private ILog log,
          IDateTimeFactory _datetimeFactory)
        {
          _configuration = configuration;
          _filesystem = filesystem;
          _log = log;
          _datetimeFactory = datetimeFactory;
        }
        public void Execute()
        {
            try
            {
                _log.Information($"{_datetimeFactory.Now.ToLongTimeString()} Starting...");
    
                var jsonFileName = Configuration["DataSource:JsonPath"];
                if (!filesystem.Exists(jsonFileName)) 
                  throw new FileNotFoundException(jsonFileName);
    
                //code if file exist...
            }
            catch (Exception ex)
            {
                _log.Fatal(ex, "Terminated unexpectedly");
                return 1;
            }
            finally
            {
                _log.CloseAndFlush();
            }
        }
    }
