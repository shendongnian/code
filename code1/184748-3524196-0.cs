    public class SomeClassThatDoesStuff
    {
        private static readonly ILog log = 
              LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public void DoStuff()
        {
             log.Info("Doing something");
        }
    }
