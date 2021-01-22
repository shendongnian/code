    private void createMenuItem_Click(object sender, EventArgs e)
    {
      DoCanvasWork(); // pick a good name :)        
    }
    private void transfer_timer() {
      System.Timers.Timer Clock = new System.Timers.Timer();
      Clock.Elapsed += new ElapsedEventHandler(Clock_Tick);
      Clock.Interval = timer_interval;  Clock.Start(); 
    }
    private void Clock_Tick( object sender, EventArgs e )
    {
      BeginInvoke( new MethodInvoker(DoCanvasWork) );
    }
    private void DoCanvasWork()
    {
      canvas.Layer.RemoveAllChildren();
      canvas.Controls.Clear();
      createDock();
    }
