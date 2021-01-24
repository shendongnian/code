    using System.Threading;
    ...
    private static Timer _myTimer;
    
    private static volatile bool _isCancled;
    
    private static void Main(string[] args)
    {
       _myTimer = new Timer(Callback, null, 2000, 2000);
    
       Console.ReadLine();
    }
    
    private static void Callback(object state)
    {
       if (_isCancled)
       {
          _myTimer.Change(0, 0);
          return;
       }
    
       try
       {
          //SendKeys.Send("KeyBoard Action");
          Console.WriteLine("blah");
       }
       catch (Exception ex)
       {
          //Handle Exception
       }
    }
