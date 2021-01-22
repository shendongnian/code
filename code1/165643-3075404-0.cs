    protected void Page_Load(object sender, EventArgs e)
    {
    this.txtName.Text = "John Jones";
    }
    
    protected void SaveDetails(object sender, EventArgs e)
    {
    string username = this.txtName.Text;
    }
