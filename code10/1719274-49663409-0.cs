    private static Timer _myTimer;
    
    private static volatile bool _isCancled;
    
    private static void Main(string[] args)
    {
       _myTimer = new Timer
          {
             Interval = 2000
          };
    
       _myTimer.Elapsed += MyTimer_Elapsed;
       _myTimer.Start();
       Console.ReadLine();
    }
    
    private static void MyTimer_Elapsed(object sender, ElapsedEventArgs e)
    {
       if (_isCancled)
       {
          _myTimer.Stop();
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
