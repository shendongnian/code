	//Created new table sample
    DataTable dt1 = new DataTable("dt1");
    dt1.Columns.Add("Id", typeof(int));
    dt1.Columns.Add("Name");
    //Added dummy data
    dt1.Rows.Add(1, "Abc");
    dt1.Rows.Add(2, "Def");
    //You must accept changes after reading file, so you can track changes
    dt1.AcceptChanges();
    //Below line will remove row permanently.
    dt1.Rows.RemoveAt(0);
    //Below line will mark row as deleted, still row count will be same till AcceptChanges() called.
    dt1.Rows[0].Delete();
    dt1.AcceptChanges();
