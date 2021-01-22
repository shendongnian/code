    protected void Page_Load(object sender, EventArgs e)
    {
        System.Diagnostics.Trace.WriteLine("Page_Load");
        if (!IsPostBack)
        {
            System.Diagnostics.Trace.WriteLine("\tBind TextBox1");
            TextBox1.Text = "Initial Value";
        }
        System.Diagnostics.Trace.WriteLine("\tTextBox1.Text = " + TextBox1.Text);
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        System.Diagnostics.Trace.WriteLine("Button1_Click");
        System.Diagnostics.Trace.WriteLine("\tTextBox1.Text = " + TextBox1.Text);
    }
