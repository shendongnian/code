    var myDataSet = new DataSet();
    
    // ** details of populating the dataset omitted **
    
    // create a foreign key relationship between Table1 and Table2.
    // add a constraint to Table2's ParentId column, indicating it must
    // existing in Table1.
    var fk = new ForeignKeyConstraint("fk", myDataSet.Tables["Table1"].Columns["ParentId"], myDataSet.Tables["Table2"].Columns["ParentId"])
    {
        DeleteRule = Rule.Cascade,
        UpdateRule = Rule.Cascade
    };
    myDataSet.Tables["Table2"].Constraints.Add(fk);
    myDataSet.EnforceConstraints = true;
    
    var connection = new SqlConnection("my connection string");
    var adapterForTable1 = new SqlDataAdapter();
    adapterForTable1.InsertCommand =
        new SqlCommand("INSERT INTO MasterTable (ParentValue) VALUES (@ParentValue); SELECT SCOPE_IDENTITY() AS ParentId", connection);
    adapterForTable1.InsertCommand.Parameters.Add("@ParentValue", SqlDbType.NVarChar).SourceColumn = "ParentValue";
    var adapterForTable2 = new SqlDataAdapter();
    adapterForTable2.InsertCommand =
        new SqlCommand("INSERT INTO ChildTable (ParentId, ChildValue) VALUES (@ParentId, @ChildValue); SELECT SCOPE_IDENTITY() AS ChildId", connection);
    adapterForTable2.InsertCommand.Parameters.Add("@ParentId", SqlDbType.Int).SourceColumn = "ParentId";
    adapterForTable2.InsertCommand.Parameters.Add("@ChildValue", SqlDbType.NVarChar).SourceColumn = "ChildValue";
    
    connection.Open();
    adapterForTable1.Update(myDataSet, "Table1"); // insert rows in parent first
    adapterForTable2.Update(myDataSet, "Table2"); // child second
