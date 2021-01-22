    protected void Page_Load(object sender, EventArgs e)
    {
       if(!IsPostBack)
       {
        TextBox1.Text = "Test 1";
       }
    }
