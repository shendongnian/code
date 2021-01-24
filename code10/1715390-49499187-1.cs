    protected void Page_Load(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedItem.Text != "Teacher")
        {
            Label9.Visible = false;
            DropDownList2.Visible = false;
        }
        else
        {
            Label9.Visible = true;
            DropDownList2.Visible = true;
        }
    }
