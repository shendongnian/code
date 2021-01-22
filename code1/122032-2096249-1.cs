    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (this.DropDownList1.SelectedItem.Text)
            {
            case "Other":
                this.TextBox1.Visible=true;
                break;
            default:
                this.TextBox1.Visible=false;
                break;
            }
    }
