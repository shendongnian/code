    MyTable myTable = new MyTable();
    TableWrapper wrapped = new TableWrapper(myTable)
    MyTableClient1 foo= new MyTableClient1(wrapped);
    
    wrapped.Table= MyTableProvider.getUpdated(myTable);
