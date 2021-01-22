    //extension method to convert my type to an object array.
    public static object[] ToObjectArray(this MyClass theSource)
    {
      object[] result = new object[3];
      result[0] = theSource.FirstDouble;
      result[1] = theSource.SecondDouble;
      result[2] = theSource.TheDateTime;
    
      return result;
    }
    
    
    //some time later, new up a dataTable, set it's columns, and then...
    
    DataTable myTable = new DataTable()
    
    DataColumn column1 = new DataColumn();
    column1.DataType = GetType("System.Double");
    column1.ColumnName = "FirstDouble";
    myTable.Add(column1);
    
    DataColumn column2 = new DataColumn();
    column2.DataType = GetType("System.Double");
    column2.ColumnName = "SecondDouble";
    myTable.Add(column2);
    
    DataColumn column3 = new DataColumn();
    column3.DataType = GetType("System.DateTime");
    column3.ColumnName = "TheDateTime";
    myTable.Add(column3);
    
    // ... Each Element becomes an array, and then a row
    MyClassList.ForEach(x => myTable.Rows.Add(x.ToObjectArray());
