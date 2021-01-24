        private int totalSeconds;
        private DateTime targetTime;
        private void button1_Click(object sender, EventArgs e)
        {
            int mins = (int)numericUpDown1.Value;
            if (mins > 0)
            {
                TimeSpan ts = TimeSpan.FromMinutes(mins);
                targetTime = DateTime.Now.Add(ts);
                totalSeconds = (int)ts.TotalSeconds;
                progressBar1.Value = 0;
                button1.Enabled = false;
                timer1.Interval = 1000;
                timer1.Start();
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = targetTime.Subtract(DateTime.Now);
            if (ts.TotalMilliseconds > 0)
            {
                label1.Text = "-" + ts.ToString(@"mm\:ss");
                double percent = ((double)totalSeconds - ts.TotalSeconds) / (double)totalSeconds;
                progressBar1.Value = (int)(progressBar1.Maximum * percent);
            }
            else
            {
                timer1.Stop();
                button1.Enabled = true;
                progressBar1.Value = progressBar1.Maximum;
                // ... do something here! ...
            }
        }
