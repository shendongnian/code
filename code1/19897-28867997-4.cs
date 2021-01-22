    private void timeOfDay_Tick(object sender, EventArgs e)
        {
            timeOfDay.Enabled = false;
            timer++;
            if (timer <= 1)
            {
                timeOfDay.Interval = 1000;
                timeOfDay.Enabled = true;             
                lblTime.Text = "Time: " + DateTime.Now.ToString("h:mm:ss tt");                  
                timer = 0;
            }
    
    }
