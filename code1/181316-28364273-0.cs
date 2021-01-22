    String strcolname = "";
    int i=0;
    //Get Data for the reader object
    using (reader = cmd.ExecuteReader())
    {  
    // Load the Data table object
    dataTable.Load(reader);
    
    //Loop thorough the DataTable object
    for (i=dataTable.Columns.Count-1;i>=0;i--)
    {
    /* 
    To be more precise , specify the column name you dont want to get    deleted, 
    (you can add multilple column names here)*/
    strcolname = dataTable.Columns[i].ColumnName.ToString();
     if (strcolname != "ABCD")
     {
      dataTable.Columns.RemoveAt(i);
     }
    }    
   }
