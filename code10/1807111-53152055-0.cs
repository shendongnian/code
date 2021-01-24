    protected void Timer1_Tick(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            StaticDataStorage.Counter++;
        }
        Label3.Text = StaticDataStorage.Counter.ToString();
    }
