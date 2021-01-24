    //Created new table
    DataTable dt1 = new DataTable("dt1");
    dt1.Columns.Add("Id", typeof(int));
    dt1.Columns.Add("Name");
    //Added dummy data
    dt1.Rows.Add(1, "Abc");
    dt1.Rows.Add(2, "Def");
    //Clone table #2 from table #1
    DataTable dt2 = dt1.Clone();
    dt2.TableName = "dt2";
    //Copy table #1 rows to table #2
    for (int i = 0; i < dt1.Rows.Count; i++)
    {
        DataRow drNew = dt2.NewRow();
        drNew.ItemArray = dt1.Rows[i].ItemArray;
        dt2.Rows.Add(drNew);
    }
