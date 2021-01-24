    var data = GetData();
    string dayType = string.Empty;
    int boundFieldIndex = 4;
    
    if(data.Tables[0].Rows.Count > 0)
    {
        dayType = data.Tables[0].Rows[0].Field<string>("dayType");
    }
    
    gridView.Columns[boundFieldIndex].Visible = dayType == "Single";
    gridView.DataSource = data.Tables[0];
    gridView.DataBind();
