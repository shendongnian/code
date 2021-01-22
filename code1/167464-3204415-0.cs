    DataTable dt = new DataTable();
    using (iDB2DataAdapter da = new iDB2DataAdapter(cmd))
    {
        da.Fill(dt);
    }
    var MyObjects = from i in dt.AsEnumerable() select new MyObject() 
        { 
             field1 = i.Field<string>("field1"), 
             field2 = i.Field<decimal>("field2")
        };
    List<MyObject> temp = MyObjects.ToList();
    return temp;
