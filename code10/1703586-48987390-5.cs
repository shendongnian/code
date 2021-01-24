    protected void Button1_Click(object sender, EventArgs e)
    {
        Label1.Text = ((Button)sender).Parent.Parent.ID;
    }
    protected void Repeater2_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Label1.Text = ((Repeater)source).ID;
    }
