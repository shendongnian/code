        private Timer myTimer;
        private static Boolean transactionCompleted;
        public Service1()
        {
            InitializeComponent();
            transactionCompleted = true;
        }
        private void TimerTick(object sender, ElapsedEventArgs args)
        {
            //check if no transaction is currently executing
            if (transactionCompleted)
            {
                transactionCompleted = false;
                ITransaction transaction = new TransactionFactory().GetTransactionFactory("RMI");
                transaction.ExecuteTransaction();
                transactionCompleted = true;
            }
            else
            {
                //do nothing and wasit for the next tick
            }
        }
        protected override void OnStart(string[] args)
        {
            // Set up a timer to trigger every 10 seconds.  
            myTimer = new Timer();
            //setting the interval for tick
            myTimer.Interval = BaseLevelConfigurationsHandler.GetServiceTimerTickInterval();
            //setting the evant handler for time tick
            myTimer.Elapsed += new System.Timers.ElapsedEventHandler(TimerTick);
            //enable the timer
            myTimer.Enabled = true;
        }
        protected override void OnStop()
        {
            //wait until transaction is finished
            while (!transactionCompleted)
            {
            }
            transactionCompleted = false;//so that no new transaction can be started
        }
