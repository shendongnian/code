    private int i;
 
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            i = 0;
        }
        else
        {
            i = Int32.Parse(Label3.Text);
            i++;           
        }
        Label3.Text = i.ToString();
    }
