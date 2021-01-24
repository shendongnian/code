     private void BindGrid()
    {
        DataTable dt = new DataTable();
        String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        MySqlConnection con = new MySqlConnection(strConnString);
        MySqlDataAdapter sda = new MySqlDataAdapter();
        MySqlCommand cmd = new MySqlCommand("GetApprovedData1");
        cmd.CommandType = CommandType.StoredProcedure;
        DateTime? dateValue = null;
        if (ViewState["Date"] != null && ViewState["Date"].ToString() != "0")
        {
            dateValue = DateTime.Parse(ViewState["Date"].ToString());
        }
        cmd.Parameters.AddWithValue("dateValue", dateValue);
        cmd.Connection = con;
        sda.SelectCommand = cmd; 
        sda.Fill(dt);
        gdvTM.DataSource = dt;
        int i = dt.Rows.Count;
        gdvTM.DataBind();
        this.BindDropDownList();
        TableCell cell = gdvTM.HeaderRow.Cells[0];
        setDropdownselectedItem(ViewState["Date"] != null ? (string)ViewState["Date"] : string.Empty, cell.FindControl("ddlgvdate") as DropDownList);
    }
