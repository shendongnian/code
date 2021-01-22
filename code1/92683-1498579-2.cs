        public class LongRunningService : ServiceBase
    {
        System.Threading.Thread processThread;
        System.Timers.Timer timer;
        private Boolean Cancel;
        protected override void OnStart(string[] args)
        {
            timer = new Timer(Settings.Default.SleepTimeHours * 3600000);
            timer.Elapsed += new ElapsedEventHandler(timer_Tick);
            timer.Start();
            Cancel = false;
        }
        protected override void OnContinue()
        {
            timer.Start();
        }
        protected override void OnPause()
        {
            timer.Stop();
        }
        protected override void OnStop()
        {
            if (processThread.ThreadState == System.Threading.ThreadState.Running)
            {
                Cancel = true;
                // Give thread a chance to stop
                processThread.Join(500);
                processThread.Abort();
            }
        }
        void timer_Tick(object sender, EventArgs e)
        {
            processThread = new System.Threading.Thread(new ThreadStart(DoWork));
            processThread.Start();
        }
        private void DoWork()
        {
            try
            {
                while (!Cancel)
                {
                if (Cancel) { return; }
                // Do General Work
                System.Threading.Thread.BeginCriticalRegion();
                {
                    // Do work that should not be aborted in here.
                }
                System.Threading.Thread.EndCriticalRegion();
                }
            }
            catch (System.Threading.ThreadAbortException tae)
            {
                // Clean up correctly to leave program in stable state.
            }
        }
    }
