    DataSet ds = new DataSet()
    DataTable sourceTable = GridView1.DataSource as DataTable;
    ds.Tables.Add(sourceTable)
    DataView view = new DataView(sourceTable);
    string[] sortData = Session["sortExpression"]!= null ? Session["sortExpression"].ToString().Trim().Split(' ') : null;
