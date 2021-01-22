    public void Timer1_Tick(Object o, EventArgs e)
    {
       if (finishedWork)
       {
         Timer1.Enabled = false;
         // do work
         Timer1.Enabled= true;
       }
    }
