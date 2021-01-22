    namespace MyClient
    {
      class Program
      {
        static void Main(string[] args)
        {
          try
          {
            bool isSuccess = SubMain(string[] args);
          }
          catch (Exception e)
          {
            HandleExceptionGracefully(e);
          }
        }
        static bool SubMain(string[] agrs)
        {
           // Do something
        }
        static void HandleExceptionGracefully(Exception e)
        {
           // Display/Send the exception in a graceful manner to the user/admin.
        }
      }
    }
