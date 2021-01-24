     [TestClass]
    public class TimerTester
    {
        [TestMethod]
        public void TestYourTimer()
        {
            var timer1 = new TimerWithParameter("param1");
            timer1.Interval = 1000;
            timer1.ElapsedEvent += Timer_ElapsedEvent;
            timer1.Start();
            var timer2 = new TimerWithParameter("param2");
            timer2.Interval = 1300;
            timer2.ElapsedEvent += Timer_ElapsedEvent;
            timer2.Start();
            Thread.Sleep(5000);
        }
        private void Timer_ElapsedEvent(object source, ElapsedEventArgs e, string strParam)
        {
            Debug.WriteLine(strParam);
        }
    }
    public delegate void ElapsedWithParameterDelegate(object source, ElapsedEventArgs e, string strParam);
    public class TimerWithParameter:Timer
    {
        private readonly string _strParam;
        public event ElapsedWithParameterDelegate ElapsedEvent;
        public TimerWithParameter(string strParam)
        {
            _strParam = strParam;
            this.Elapsed += TimerWithParameter_Elapsed;
        }
        private void TimerWithParameter_Elapsed(object sender, ElapsedEventArgs e)
        {
            ElapsedEvent?.Invoke(this, e, _strParam);
        }
    }
