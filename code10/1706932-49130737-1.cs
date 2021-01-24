    public class ZLogger
    {
      Serilog.ILogger logger = null; // >>>>>> Had to move this out of Property get method <<<<<
      public Serilog.ILogger Logger
      {
          get
          {
              
              if (logger == null)
              {
                  logger = new LoggerConfiguration()
                  .Destructure.ByTransforming<MySqlConnectionInfo>(
                    ....
