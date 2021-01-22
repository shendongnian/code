    Index index = new Index(table, "PK_tableNameTable");
    index.IndexKeyType = IndexKeyType.DriPrimaryKey;
    //You will have to store the names of columns before deleting the key.
    index.IndexedColumns.Add(new IndexedColumn(index,"ID")); 
    
    table.Indexes.Add(index);
