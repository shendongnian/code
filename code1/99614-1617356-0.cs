    // Set the identical columns to compare by in first table
    table1.PrimaryKey = new DataColumn[]
                            { idColumnOfTable1, anotherIDColumnOfTable1 };
    // Set the identical columns to compare by in second table
    table2.PrimaryKey = new DataColumn[]
                            { idColumnOfTable2, anotherIDColumnOfTable2 };
    
    // The MissingSchemaAction.Add will add the non-identical columns
    // Non-identical columns existing in from table 2 will be added to table1
    table1.Merge(table2, false, MissingSchemaAction.Add);
