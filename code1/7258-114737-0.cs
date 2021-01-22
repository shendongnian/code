    protected void GridView1_DataBound(object sender, EventArgs e)
        {
            if (GridView1.Rows.Count == 1)
                GridView1.Rows[0].Visible = false;
        }
