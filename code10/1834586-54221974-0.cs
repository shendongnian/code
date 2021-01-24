    private void Form1_Load(object sender, EventArgs e)
    {
        timer1.Tick += timer1_Tick;
        timer1.Interval = (int) TimeSpan.FromMinutes(15).TotalMilliseconds;
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
        checkBox1.Enabled = true;
        timer1.Stop();
    }
    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (!checkBox1.Checked)
        {
            checkBox1.Enabled = false;
            timer1.Start();
        }
    }
