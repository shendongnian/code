    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        for (int i = 0; i < e.Row.Cells.Count; i++)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string decodedText = HttpUtility.HtmlDecode(e.Row.Cells[i].Text);
                e.Row.Cells[i].Text = decodedText;
            }
        }
    }
