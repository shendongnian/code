    DataTable dt = new DataTable();
    // Define all of the columns you are binding in your GridView
    dt.Columns.Add("AColumnName");
    ...
    ...
    DataRow dr = dt.NewRow();
    dt.Rows.Add(dr);
    myGridView.DataSource = dt;
    myGridView.DataBind();
