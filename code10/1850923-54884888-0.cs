    DataTable dt = new DataTable();
    dt.Columns.Add("customcolumnname");
    DataRow dr = dt.NewRow();
    dr["customcolumnname"] = "columnvalue";
    dt.Rows.Add(dr);
    SqlParameter[] parCollection = new SqlParameter[1];
    parCollection[0] = new SqlParameter("@yourdt", dt);
