    private void ptNotifyIcon_BalloonTipShown(object sender, EventArgs e)
    {
        timer1.Enabled = true;
        balloonTipActive = 0;
    }
    
    private void timer1_Tick(object sender, EventArgs e)
    {
    
       balloonTipActive++;
    
       if (balloonTipActive == 40)
       {
         ptNotifyIcon.Visible = false;
         ptNotifyIcon.Visible = true;
         balloonTipActive = 0;
         timer1.Enabled = false;
       }
    }
