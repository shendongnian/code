    class Program
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer(new TimerCallback(TimeCallBack),null,1000,50000);
            Console.Read();
            timer.Dispose();
        }
        public static void TimeCallBack(object o)
        {
          curMinute = DateTime.Now.Minute;
          if (lastMinute < curMinute) {
           // do your once-per-minute code here
           lastMinute = curMinute;
        }
    }
