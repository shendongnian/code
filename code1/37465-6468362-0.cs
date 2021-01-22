    protected void Page_Load(object sender, EventArgs e)
    {
        dt.Columns.Add("ExpId", typeof(int));
        dt.Columns.Add("FirstName", typeof(string));
    }
    protected void BtnLoad_Click(object sender, EventArgs e)
    {
        //   gvLoad is Grid View Id
        if (gvLoad.Rows.Count == 0)
        {
            Gds.Tables.Add(tblLoad());
        }
        else
        {
            dt = tblGridRow();
            dt.Rows.Add(tblRow());
            Gds.Tables.Add(dt);
        }
        gvLoad.DataSource = Gds;
        gvLoad.DataBind();
    }
    protected DataTable tblLoad()
    {
        dt.Rows.Add(tblRow());
        return dt;
    }
    protected DataRow tblRow()
    {
        DataRow dr;
        dr = dt.NewRow();
        dr["Exp Id"] = Convert.ToInt16(txtId.Text);
        dr["First Name"] = Convert.ToString(txtName.Text);
        return dr;
    }
    protected DataTable tblGridRow()
    {
        DataRow dr;
        for (int i = 0; i < gvLoad.Rows.Count; i++)
        {
            if (gvLoad.Rows[i].Cells[0].Text != null)
            {
                dr = dt.NewRow();
                dr["Exp Id"] = gvLoad.Rows[i].Cells[1].Text.ToString();
                dr["First Name"] = gvLoad.Rows[i].Cells[2].Text.ToString();
                dt.Rows.Add(dr);
            }
        }
        return dt;
    }
    protected void btn_Click(object sender, EventArgs e)
    {
        dt = tblGridRow();
        dt.Rows.Add(tblRow());
        Session["tab"] = dt;
        // Response.Redirect("Default.aspx");
    }
     
    protected void gvLoad_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dt = tblGridRow();
        dt.Rows.RemoveAt(e.RowIndex);
        gvLoad.DataSource = dt;
        gvLoad.DataBind();
    }
}
