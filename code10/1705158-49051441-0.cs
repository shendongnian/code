    List<Timer> GlobalTimers=new List<Timer>();
    private void button1_Click(object sender, EventArgs e)
        {
         Timer timer = new Timer();
            timer.Interval = update;
            timer.Tag = i;
            timer.Tick += new EventHandler(timer_Tick);            
            timer.Start();
            timer.Enabled = true;
            GlobalTimers.Add(timer);
         }
      private void button2_Click(object sender, EventArgs e)
      {
          foreach (var item in GlobalTimers)
          {
                if (timer.Tag ==1)
                {
                    item.Stop();
                    item.Dispose();
                }
           }
      }
