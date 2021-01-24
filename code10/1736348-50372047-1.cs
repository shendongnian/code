    var changes = new DataTable("Rows");
    var column = new DataColumn { DataType = typeof(MyString), ColumnName = "File" };
    changes.Columns.Add(column);
    var primKey = new DataColumn[1];
    primKey[0] = column;
    changes.PrimaryKey = primKey;
    changes.Rows.Add((MyString)"a");
    changes.Rows.Add((MyString)"4.txt");
    try
    {
        changes.Rows.Add((MyString)"４.txt"); // throws the exception
    }
    catch (Exception e)
    {
        Console.WriteLine("Exception: {0}", e);
    }
    var row = changes.Rows.Find((MyString)"A");
