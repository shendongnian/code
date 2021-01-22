    using System;
    namespace UserDefinedException
    {
       class TestTemperature
       {
          static void Main(string[] args)
          {
             Temperature temp = new Temperature();
             try
             {
                temp.showTemp();
             }
             catch(TempIsZeroException e)
             {
                Console.WriteLine("TempIsZeroException: {0}", e.Message);
             }
             Console.ReadKey();
          }
       }
    }
    public class TempIsZeroException: ApplicationException
    {
       public TempIsZeroException(string message): base(message)
       {
       }
    }
    public class Temperature
    {
       int temperature = 0;
       public void showTemp()
       {
          if(temperature == 0)
          {
             throw (new TempIsZeroException("Zero Temperature found"));
          }
          else
          {
             Console.WriteLine("Temperature: {0}", temperature);
          }
       }
    }
and for throwing an exception,
You can throw an object if it is either directly or indirectly derived from the [System.Exception][2] class
    Catch(Exception e)
    {
       ...
       Throw e
    }
