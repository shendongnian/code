        static void Main(string[] args)
        {
            Timer timer = new Timer(new TimerCallback(TimCallBack),null,1000,50000);
            Console.Read();
            timer.Dispose();
        }
        public static void TimCallBack(object o)
        {
          curMinute = DateTime.Now.Minute;
          if (lastMinute < curMinute) {
           // do your once-per-minute code here
           lastMinute = curMinute;
        }
	}
