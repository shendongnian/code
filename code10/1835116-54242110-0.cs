    protected void lbDetail_Click(object sender, EventArgs e)
    {
        GridViewRow clickedRow = ((LinkButton)sender).NamingContainer as GridViewRow;
        Label1.Text = clickedRow.Cells[1].Text;
    }
