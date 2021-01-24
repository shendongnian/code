    protected void OnSelectedIndexChanged1(object sender, EventArgs e)
    {
        //Get the selected row
        GridViewRow row = GridView1.SelectedRow;
        if (row != null)
        {
            // With 
            // TextBox1.Text = (row.FindControl("lblLocalTime") as Label).Text;
            // Without
            TextBox1.Text = Server.HtmlDecode(row.Cells[1].Text.Trim());
        }
    }
