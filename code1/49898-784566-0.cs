    public void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
         TextBox1.Text = ((TextBox)GridView1.Rows[e.RowIndex]
                                  .FindControl("textBoxNotes")).Text;
    }
