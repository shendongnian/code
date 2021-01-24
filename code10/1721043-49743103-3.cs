    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Bind DropDownList1 with some testing data
            DropDownList1.Items.Add(new ListItem() { Text = "Item 001", Value = "1" });
            DropDownList1.Items.Add(new ListItem() { Text = "Item 002", Value = "2" });
            DropDownList1.Items.Add(new ListItem() { Text = "Item 003", Value = "3" });
            DropDownList1.Items.Add(new ListItem() { Text = "Item 004", Value = "4" });
            DropDownList1.Items.Add(new ListItem() { Text = "Item 005", Value = "5" });
        }
    }
    
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        TextBox1.Text = DropDownList1.SelectedValue;
    }
