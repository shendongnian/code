    private void timer1_Tick(object sender, EventArgs e)
        {
            if (countUpCheckbox.Checked)
            {
                Invoke(new Action(() =>
                {
                    timespan.Add(TimeSpan.FromSeconds(1));
                    richTextBox1.Text = string.Format("{0}:{1}:{2}", timespan.Hours.ToString().PadLeft(2, '0'), timespan.Minutes.ToString().PadLeft(2, '0'), timespan.Seconds.ToString().PadLeft(2, '0'));
                }));
            }
            if (countdownCheckbox.Checked)
            {
                Invoke(new Action(() =>
                {
                    timespan.Add(TimeSpan.FromSeconds(1));
                    richTextBox1.Text = string.Format("{0}:{1}:{2}", timespan.Hours.ToString().PadLeft(2, '0'), timespan.Minutes.ToString().PadLeft(2, '0'), timespan.Seconds.ToString().PadLeft(2, '0'));
                }));
            }
        }
