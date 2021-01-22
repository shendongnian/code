    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text != "")
        {
            Label Label1 = FindControlRecursive(Page, "Label1") as Label;
            if(Label1 != null)
                Label1.Text = "<b>The text you entered was: " + TextBox1.Text + ".</b>";
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Label Label1 = FindControlRecursive(Page, "Label1") as Label;
        if (Label1 != null)
            Label1.Text = "<b>You chose <u>" + DropDownList1.SelectedValue + "</u> from the dropdown menu.</b>";
    }
    private Control FindControlRecursive(Control root, string id)
    {
        if (root.ID == id) return root;
        foreach (Control c in root.Controls)
        {
            Control t = FindControlRecursive(c, id);
            if (t != null) return t;
        }
        return null;
    }
