     public class EServerAPI : IEServerAPI
        { 
        	public EServerAPI()
        	{ 
        		try
        		{ 
        			System.IO.File.WriteAllText("E:\\InitLog.txt", "Going to initialize logger.");
        			Log.Logger = new LoggerConfiguration()
                                     .WriteTo.File("logs\\myapp.txt", rollingInterval: RollingInterval.Day)
                                     .CreateLogger();
        			Log.Information("Hello, world!");
        			System.IO.File.WriteAllText("E:\\InitLogEnd.txt", "Initialize logger has end.");
        		}
        		catch(Exception ex) 
        		{ 
        			System.IO.File.WriteAllText("E:\\exception.txt",ex.Message); 
        		}
        		catch 
        		{ 
        			System.IO.File.WriteAllText("E:\\unhandExce.txt","unhandled excpetion occur");
        		}
        	}
        }
