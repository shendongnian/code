    public class LoggedClass
    {
         private Logger Logger { get; set; }
         public LoggerClass( Logger logger )
         {
              this.Logger = logger;
         }
         public void A()
         {
             this.Logger.Info( "A has been called" );
             ...
         }
    }
