    protected void AddRow_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        //check if the viewstate exists
        if (ViewState["myTable"] != null)
        {
            //cast the viewstate back to a datatable
            dt = ViewState["myTable"] as DataTable;
        }
        else
        {
            //add columns to tne new datatable
            dt.Columns.Add("Title");
            dt.Columns.Add("Type");
            //add the table to the viewstate
            ViewState["myTable"] = dt;
        }
        string title = "title " + dt.Rows.Count;
        string selection = "selection " + dt.Rows.Count;
        DataRow dr = dt.NewRow();
        dr["Title"] = title;
        dr["Type"] = selection;
        dt.Rows.Add(dr);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
