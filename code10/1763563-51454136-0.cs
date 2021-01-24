     private static System.Timers.Timer EmailTimer;
        static void Main(string[] args)
        {
            int sleepingTime = int.Parse(ConfigurationSettings.AppSettings["SleepInMiliSecond"]);
            EmailTimer = new System.Timers.Timer();
            EmailTimer.Elapsed += Timer_Elapsed;
            EmailTimer.Enabled = true;
            EmailTimer.Start();
        }
        private static void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            EmailTimer.Enabled = false;
            try
            {
                StartRunning();
            }
            finally
            {
                EmailTimer.Enabled = true;
            }
        }
        private static void StartRunning()
        {
            Log("Process Start Running...");
            ProcessWarranty();
            CheckEmailSendingResult();
            Log("Process End...");
        }
