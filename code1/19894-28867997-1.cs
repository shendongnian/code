            timerTip.Enabled = false;
            timer++;
            if (timer <= 1)
            {
                timerTip.Interval = 1000;
                timerTip.Enabled = true;             
                lblTime.Text = "Time: " + DateTime.Now.ToString("h:mm:ss tt");                  
                timer = 0;
            }
    
