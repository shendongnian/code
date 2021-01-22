    DataTable dt1 = new DataTable("A");
    DataTable dt2 = new DataTable("B");
    dt1.Columns.Add("ID", typeof(int));
    dt1.PrimaryKey = new DataColumn[] {dt1.Columns[0]};
    dt1.Rows.Add(1);
    dt1.Rows.Add(2);
    dt1.Rows.Add(3);
    
    dt2.Columns.Add("ID", typeof(int));
    dt2.Rows.Add(1);
    dt2.Rows.Add(2);
    dt2.Rows.Add(4);
    ds.Tables.Add(dt1);
    ds.Tables.Add(dt2);
    ds.Relations.Add("ID_REL", dt1.Columns[0], dt2.Columns[0]);
    
    foreach (DataRow r in ds.Tables["A"].Rows)
    {
        DataRow []child=r.GetChildRows("ID_REL");
        Console.Write(r[0] + " " );
        if (child.Length != 0)
            Console.WriteLine(child[0][0]);
        Console.WriteLine();
    }
