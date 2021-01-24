    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            CheckBox1.Enabled = false;
            CheckBox1.Checked = true;
        }
    }
