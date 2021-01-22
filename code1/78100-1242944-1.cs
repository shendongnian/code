    DataTable dtbl = new DataTable();
        if (ViewState["dtbl"] == null)
        {
            DataColumn PID = new DataColumn();//Adding column When adding item first time
            dtbl.Columns.Add(PID);
            DataColumn PName = new DataColumn();
            dtbl.Columns.Add(PName);
        }
        else
        {
            dtbl = (DataTable)ViewState["dtbl"];
        }
        DataRow dr = dtbl.NewRow();
        dr["PID"] = "1";
        dr["PName"] = "product Name";
        dtbl.Rows.Add(dr);
        ViewState.Add("dtbl", dtbl);
        yourGridView.DataSource = dtbl.DefaultView;
        yourGridView.DataBind();
