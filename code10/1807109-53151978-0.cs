    private int i;
 
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            i = 0;
        }
        else
        {
            i++;
            Label3.Text = i.ToString();
        }
    }
