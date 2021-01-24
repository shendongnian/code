    private void Form1_Load(object sender, EventArgs e)
    {
        // These could also be done in through designer & property window instead
        timer1.Tick += timer1_Tick; // Hook up the Tick event
        timer1.Interval = (int) TimeSpan.FromMinutes(15).TotalMilliseconds; // Set the Interval
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
        // When the Interval amount of time has elapsed, enable the checkbox and stop the timer
        checkBox1.Enabled = true;
        timer1.Stop();
    }
    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (!checkBox1.Checked)
        {
            // When the checkbox is unchecked, disable it and start the timer
            checkBox1.Enabled = false;
            timer1.Start();
        }
    }
