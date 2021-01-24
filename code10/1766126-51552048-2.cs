    private void GetData()
    
    {
    
        DataTable dt;
    
        if (ViewState["SelectedRecords"] != null)
    
            dt = (DataTable)ViewState["SelectedRecords"];
    
        else
    
            dt = CreateDataTable();
    
        CheckBox chkAll = (CheckBox)gvAll.HeaderRow
    
                            .Cells[0].FindControl("chkAll");
    
        for (int i = 0; i < gvAll.Rows.Count; i++)
    
        {
    
            if (chkAll.Checked)
    
            {
    
                dt = AddRow(gvAll.Rows[i], dt);
    
            }
    
            else
    
            {
    
                CheckBox chk = (CheckBox)gvAll.Rows[i]
    
                                .Cells[0].FindControl("chk");
    
                if (chk.Checked)
    
                {
    
                    dt = AddRow(gvAll.Rows[i], dt);
    
                }
    
                else
    
                {
    
                    dt = RemoveRow(gvAll.Rows[i], dt);
    
                }
    
            }
    
        }
    
        ViewState["SelectedRecords"] = dt;    
    }
    private DataTable CreateDataTable()
    
    {
    
        DataTable dt = new DataTable();
    
        dt.Columns.Add("CustomerID");
    
        dt.Columns.Add("ContactName");
    
        dt.Columns.Add("City");
    
        dt.AcceptChanges();
    
        return dt;
    
    }
    private DataTable AddRow(GridViewRow gvRow, DataTable dt)
    
    {
    
        DataRow[] dr = dt.Select("CustomerID = '" + gvRow.Cells[1].Text + "'");
    
        if (dr.Length <= 0)
    
        {
    
            dt.Rows.Add();
    
            dt.Rows[dt.Rows.Count - 1]["CustomerID"] = gvRow.Cells[1].Text;
    
            dt.Rows[dt.Rows.Count - 1]["ContactName"] = gvRow.Cells[2].Text;
    
            dt.Rows[dt.Rows.Count - 1]["City"] = gvRow.Cells[3].Text;
    
            dt.AcceptChanges();
    
        }
    
        return dt;
    
    }
    private DataTable RemoveRow(GridViewRow gvRow, DataTable dt)
    
    {
    
        DataRow[] dr = dt.Select("CustomerID = '" + gvRow.Cells[1].Text + "'");
    
        if (dr.Length > 0)
    
        {
    
            dt.Rows.Remove(dr[0]);
    
            dt.AcceptChanges();
    
        }
    
        return dt;
    
    }
    protected void OnPaging(object sender, GridViewPageEventArgs e)
    
    {
    
        GetData();
    
        gvAll.PageIndex = e.NewPageIndex;
    
        BindGridone();
    
        SetData();
    
    }
    protected void CheckBox_CheckChanged(object sender, EventArgs e)
    
    {
    
        GetData();
    
        SetData();
    
        BindGridtwo();
    
    }
    private void BindGridtwo()
    
    {
    
        DataTable dt = (DataTable)ViewState["SelectedRecords"];
    
        gvSelected.DataSource = dt;
    
        gvSelected.DataBind();
    
    }
