    public class MyClassThatLogs
    {
        public MyClassThatLogs(ILogger logger)
        {
            try
            {
                logger.Write("bla bla bla");
            }
            catch(Exception ex)
            {
                logger.Write(ex); //overload of Write() that takes in an Exception
            }
        }
    }
