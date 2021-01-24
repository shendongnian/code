    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DateTime time = Convert.ToDateTime(e.CommandArgument);
        Label1.Text = time.ToString("HH:mm");
    }
