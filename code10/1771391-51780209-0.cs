    // You can specify the Catalog, Schema, Table Name, Table Type to get 
    // the specified table(s).
    // You can use four restrictions for Table, so you should create a 4 members array.
    String[] tableRestrictions = new String[4];
    // For the array, 0-member represents Catalog; 1-member represents Schema; 
    // 2-member represents Table Name; 3-member represents Table Type. 
    // Now we specify the Table Name of the table what we want to get schema information.
    tableRestrictions[2] = "Course";
    DataTable courseTableSchemaTable = conn.GetSchema("Tables", tableRestrictions);
