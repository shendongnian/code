        var dt = new DataTable();
        dt.Columns.Add("ID", typeof(string));
        dt.Columns.Add("BATCH NUM", typeof(string));
        dt.Columns.Add("QTY", typeof(int));
        var row = dt.NewRow();
        row["BATCH NUM"] = 1;
        row["QTY"] = 10;
        dt.Rows.Add(row);
        var val1 = dt.Rows[0][0]?.ToString();              //EMPTY
        var val2 = dt.Rows[0][1]?.ToString();              //1
        var val3 = dt.Rows[0][2]?.ToString();              //10
        var val4 = dt.Rows[0]["ID"]?.ToString();           //EMPTY
        var val5 = dt.Rows[0]["BATCH NUM"]?.ToString();    //1
        var val6 = dt.Rows[0]["QTY"]?.ToString();          //10
