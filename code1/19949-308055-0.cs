        public Form1()
        {
            InitializeComponent();
            //some fake data, obviously you would have your own.
            DateTime someStart = DateTime.Now.AddMinutes(1);
            TimeSpan someInterval = TimeSpan.FromMinutes(2);
            
            //sample call
            StartTimer(someStart,someInterval,doSomething);
        }
        //just a fake function to call
        private bool doSomething()
        {
            DialogResult keepGoing = MessageBox.Show("Hey, I did something! Keep Going?","Something!",MessageBoxButtons.YesNo);
            return (keepGoing == DialogResult.Yes);
        }
       
        //The following is the actual guts.. and can be transplanted to an actual class.
        private delegate void voidFunc<P1,P2,P3>(P1 p1,P2 p2,P3 p3);
        public void StartTimer(DateTime startTime, TimeSpan interval, Func<bool> action)
        {
            voidFunc<DateTime,TimeSpan,Func<bool>> Timer = TimedThread;
            Timer.BeginInvoke(startTime,interval,action,null,null);
        }
        private void TimedThread(DateTime startTime, TimeSpan interval, Func<bool> action)
        {
            bool keepRunning = true;
            DateTime NextExecute = startTime;
            while(keepRunning)
            {
                if (DateTime.Now > NextExecute)
                {
                    keepRunning = action.Invoke();
                    NextExecute = NextExecute.Add(interval);
                }
                //could parameterize resolution.
                Thread.Sleep(1000);
            }            
        }
