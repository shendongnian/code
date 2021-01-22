      public override void Start()
      {
          // Within the Service Start
          System.Windows.Forms.Timer timer = new Timer();
          timer.Tick += new EventHandler(timer_Tick);
          timer.Interval = Settings.Default.SleepTimeHours * 3600000;
          timer.Start();
      }
      System.Threading.Thread processThread;
      void timer_Tick(object sender, EventArgs e)
      {
         processThread = new System.Threading.Thread(new ThreadStart(DoWork));
         processThread.Start();
         // Call processThread.Abort() on the Stop() for the Service.
      }
      private void DoWork()
      {
          try
          {
              // Do Work
              // Lock critical sections
          }
          catch (ThreadAbortException tae)
          {
              // Clean up correctly
          }
      }
