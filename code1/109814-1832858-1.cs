    protected void Timer1_Tick(object sender, EventArgs e)
    {
      this.Timer1.Enabled = false;
      StartLongRunningTask();                            
    }
