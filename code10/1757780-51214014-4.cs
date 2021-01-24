    public class Program
        {
            public static void Main(string[] args)
            {
                Log.Logger = new LoggerConfiguration()
                    .WriteTo.Logger(cc => cc.Filter.ByIncludingOnly(WithProperty("EventId",1001)).WriteTo.File("Test1001.txt",flushToDiskInterval: TimeSpan.FromSeconds(1)))
                    .WriteTo.Logger(cc => cc.Filter.ByIncludingOnly(WithProperty("EventId", 2001)).WriteTo.File("Test2001.txt", flushToDiskInterval: TimeSpan.FromSeconds(1)))
                    .CreateLogger();
    
                CreateWebHostBuilder(args).Build().Run();
            }
    
            public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
                WebHost.CreateDefaultBuilder(args).UseSerilog()
                    .UseStartup<Startup>();
    
            public static Func<LogEvent, bool> WithProperty(string propertyName, object scalarValue)
            {
                if (propertyName == null) throw new ArgumentNullException("propertyName");           
                ScalarValue scalar = new ScalarValue(scalarValue);
                return e=>
                {
                    LogEventPropertyValue propertyValue;
                    if (e.Properties.TryGetValue(propertyName, out propertyValue))
                    {
                        var stValue = propertyValue as StructureValue;
                        if (stValue != null)
                        {
                            var value = stValue.Properties.Where(cc => cc.Name == "Id").FirstOrDefault();
                            bool result = scalar.Equals(value.Value);
                            return result;
                        }
                    }
                    return false;
                };
            }
        }
