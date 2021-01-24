    private TimeSpan quick = TimeSpan.FromHours(2); // 2 hours
    private void timer1_Tick(object sender, EventArgs e)
    {
        quick -= TimeSpan.FromMinutes(1); // subtract 1 minute
        label1.Text = string.Format("{0:h\\:mm}", quick);
    }
