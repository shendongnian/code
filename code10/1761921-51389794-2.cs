    private DateTime start = DateTime.Now;
    void timer_Tick(object sender, EventArgs e)
    {  
        TimeTb.Text = (DateTime.Now - start).ToString();
    }
