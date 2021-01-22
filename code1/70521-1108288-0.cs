    DataSet mySet = new DataSet();
    mySet.LoadXml("myfile.xml");
    myTable = mySet.Tables[0];
    myCols = myTable.Columns;
    Console.Writeline("Column Names: {0}, {1}, {2}",
        myCols[0].ColumnName, myCols[1].ColumnName, myCols[2].ColumnName);
    ... result ...
    Column Names: Name, Artist, Genre
