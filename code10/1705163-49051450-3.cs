    List<Timer> TimerList =new List<Timer>();
    int i=0;
    private void button1_Click(object sender, EventArgs e)
    {
        Timer timer = new Timer();
        // code here
        TimerList.Add(timer);
    }
    private void button2_Click(object sender, EventArgs e)
    {
         foreach (Timer t in GlobalTimers)
         {
               if (t.Tag ==1)
               {
                   t.Stop();
                   t.Dispose();
               }
          }
     }   
