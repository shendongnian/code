    protected void Timer1_Tick(object sender, EventArgs e)
    {
        StaticDataStorage.Counter++;
        Label3.Text = StaticDataStorage.Counter.ToString();
    }
