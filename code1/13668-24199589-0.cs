    DataTable dtOptions = new DataTable();
    DataColumn[] dcColumns = { new DataColumn("Text", Type.GetType("System.String")), 
                               new DataColumn("Value", Type.GetType("System.String"))};
    dtOptions.Columns.AddRange(dcColumns);
    foreach (ListItem li in ddlOperation.Items)
    {
       DataRow dr = dtOptions.NewRow();
       dr["Text"] = li.Text;
       dr["Value"] = li.Value;
       dtOptions.Rows.Add(dr);
    }
    DataView dv = dtOptions.DefaultView;
    dv.Sort = "Text";
    ddlOperation.Items.Clear();
    ddlOperation.DataSource = dv;
    ddlOperation.DataTextField = "Text";
    ddlOperation.DataValueField = "Value";
    ddlOperation.DataBind();
