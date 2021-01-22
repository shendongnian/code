    protected void Page_Load(object sender, EventArgs e)
    {
        noviTest = new MyClass(TextBox1.Text);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Button1.Visible = false;
        Button2.Visible = true;    
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Label1.Text = noviTest.getID;
    }
