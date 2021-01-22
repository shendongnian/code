    DataSet1 ds = new DataSet1();
    
    //load data
    DataSet1.ChildTable.SortExpression = "Order";
    DataSet1.ParentTableRow parentRow = ds.ParentTable.FindByID(1);
    DataSet1.ChildTableRow[] childRows = parentRow.GetChildTableRows();
    Array.Sort<DataSet1.ChildTableRow>(childRows, new ChildTableCoparer());
    //Enumerate fields is right order    
    
