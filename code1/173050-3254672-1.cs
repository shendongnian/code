        DataTable dt1 = new DataTable();
        dt1.Columns.Add("col1", typeof(string));
        dt1.Columns.Add("col2", typeof(string));
        dt1.Columns.Add("col3", typeof(string));
        DataTable dt2 = new DataTable();
        dt2.Columns.Add("cola", typeof(string));
        dt2.Columns.Add("colb", typeof(string));
        object[] row = {'1', '2', '3'};
        dt1.Rows.Add(row);
        object[] row1 = { 'a', 'b' };
        dt2.Rows.Add(row1);
        // Create columns in dt1
        dt1.Columns.Add("cola", typeof(string));
        dt1.Columns.Add("colb", typeof(string));
      
        // Copy data from dt2
        dt1.Rows[0]["cola"] = dt2.Rows[0]["cola"];
        dt1.Rows[0]["colb"] = dt2.Rows[0]["colb"];
