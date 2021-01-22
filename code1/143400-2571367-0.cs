    DataTable dtBindGrid = new DataTable();
    dtBindGrid = serviceobj.SelectExamTimeTable(...);
    dtBindGrid.Columns.Add(new DataColumn("DatedTime"));
    foreach (DataRow row in dtBindGrid.Rows)
    {
        DatedTime = Convert.ToDateTime(row["Time"].ToString());
        strgettime = DatedTime.ToString("t");
        row.BeginEdit();
        row.SetField("DatedTime", strgettime);
        row.EndEdit();
        row.AcceptChanges();
    }
    GrdExamTimeTable.DataSource = dtBindGrid.DefaultView;
    GrdExamTimeTable.DataBind();
