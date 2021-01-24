     class Program
     {
         static System.Threading.Timer _ttimer;
    
         static void Main(string[] args)
         {
    
             SetupTimerTo30sec();
             Console.ReadLine();
         }
    
        private static void SetupTimerTo30sec()
         {
             var now = DateTime.Now;
             int diffMilliseconds;
             if (now.Second < 30)
             {
                 diffMilliseconds = (30 - now.Second) * 1000;
             }
             else
             {
                 diffMilliseconds = (60 - now.Second) * 1000;
             }
             diffMilliseconds -= now.Millisecond;
    
             if (_ttimer != null)
             {
                 _ttimer.Change(diffMilliseconds, 30 * 1000);
             }
             else
             {
                 _ttimer = new Timer(OnElapsed, null, diffMilliseconds, 30 * 1000);
             }
         }
    
         private static void OnElapsed(object state)
         {
             Console.Write(DateTime.Now.ToLongTimeString());
             Console.WriteLine($":{DateTime.Now.Millisecond}");
             SetupTimerTo30sec();
         }
     }
