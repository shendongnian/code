    protected  void Page_Load(object sender, EventArgs e)
    {
        Timer1.Interval = 2000;
        Timer1.Enabled = true;
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
            Label3.Text = "done";
    }
 
    
