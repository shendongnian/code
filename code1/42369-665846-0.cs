        DataTable dt1 = new DataTable();
        dt1.Columns.Add("CustID", typeof(int));
        dt1.Columns.Add("ColX", typeof(int));
        dt1.Columns.Add("ColY", typeof(int));
        DataTable dt2 = new DataTable();
        dt2.Columns.Add("CustID", typeof(int));
        dt2.Columns.Add("ColZ", typeof(int));
        for (int i = 1; i <= 5; i++)
        {
            DataRow row = dt1.NewRow();
            row["CustID"] = i;
            row["ColX"] = 10 + i;
            row["ColY"] = 20 + i;
            dt1.Rows.Add(row);
            row = dt2.NewRow();
            row["CustID"] = i;
            row["ColZ"] = 30 + i;
            dt2.Rows.Add(row);
        }
        var results = from table1 in dt1.AsEnumerable()
                     join table2 in dt2.AsEnumerable() on (int)table1["CustID"] equals (int)table2["CustID"]
                     select new
                     {
                         CustID = (int)table1["CustID"],
                         ColX = (int)table1["ColX"],
                         ColY = (int)table1["ColY"],
                         ColZ = (int)table2["ColZ"]
                     };
        foreach (var item in results)
        {
            Console.WriteLine(String.Format("ID = {0}, ColX = {1}, ColY = {2}, ColZ = {3}", item.CustID, item.ColX, item.ColY, item.ColZ));
        }
        Console.ReadLine();
    // Output:
    // ID = 1, ColX = 11, ColY = 21, ColZ = 31
    // ID = 2, ColX = 12, ColY = 22, ColZ = 32
    // ID = 3, ColX = 13, ColY = 23, ColZ = 33
    // ID = 4, ColX = 14, ColY = 24, ColZ = 34
    // ID = 5, ColX = 15, ColY = 25, ColZ = 35
