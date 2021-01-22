    private void timer1_Tick(object sender, EventArgs e)
    {
    
        TimeSpan ts = stopWatch.Elapsed;
    
        // Format and display the TimeSpan value.
        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
    
        label3.Text = elapsedTime;
        labelClicks.Text = "User clicked " + clicksNo.toString() + "nt times..";
    
        if (stopWatch.ElapsedMilliseconds >= this.minutes * 60 * 1000) 
        {
            timer1.Stop();
            MessageBox.Show("Time elapsed.");
            hasTimerStarted = false;
            numberOfClicks = 0;
        }
    }
