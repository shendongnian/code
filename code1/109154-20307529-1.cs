    Type tableType = Assembly.GetExecutingAssembly().GetType("NameSpace.TableName");
    ITable itable = dbcontext.GetTable(tableType);
    
    //prints contents of the table
    foreach (object y in itable) {
        string value = (string)y.GetType().GetProperty("ColumnName").GetValue(y, null);
        Console.WriteLine(value);
    }
    //inserting into a table
    dynamic tableClass = Activator.CreateInstance(tableType);
    //Alternative to using tableType
    dynamic tableClass = Activator.CreateInstance(null, "NameSpace.TableName").Unwrap();
    tableClass.Word = userParameter;
    itable.InsertOnSubmit(tableClass);
    dbcontext.SubmitChanges();
    //sql equivalent
    dbcontext.ExecuteCommand("INSERT INTO [TableName]([ColumnName]) VALUES ({0})", userParameter);
