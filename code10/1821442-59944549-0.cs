    static void Main(string[] args)
            {  
                 SelfLog.Out = Console.Error;
                Serilog.Debugging.SelfLog.Enable(msg => Debug.WriteLine(msg));
                var log = new LoggerConfiguration()
                .WriteTo.MongoDB("mongodb://Localhost/logs", collectionName: "applog",period:TimeSpan.Zero)
                .MinimumLevel.Debug()
                .CreateLogger();
                log.Error("Log From app");
                for (int i = 0; i <500 ; i++)
                {
                    log.Error("Log From app" + i);
                }
                Thread.Sleep(2000);
            }
        }
