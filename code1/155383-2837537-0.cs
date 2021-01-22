    public static DataTable csvToDataTable(string file, bool isRowOneHeader)
    {
    
    DataTable csvDataTable = new DataTable();
    
    //no try/catch - add these in yourselfs or let exception happen
    String[] csvData = File.ReadAllLines(HttpContext.Current.Server.MapPath(file));
    
    //if no data in file ‘manually’ throw an exception
    if (csvData.Length == 0)
    {
        throw new Exception(”CSV File Appears to be Empty”);
    }
    
    String[] headings = csvData[0].Split(',');
    int index = 0; //will be zero or one depending on isRowOneHeader
    
    if(isRowOneHeader) //if first record lists headers
    {
        index = 1; //so we won’t take headings as data
       
        //for each heading
        for(int i = 0; i < headings.Length; i++)
        {
            //replace spaces with underscores for column names
            headings[i] = headings[i].Replace(” “, “_”);
    
           //add a column for each heading
            csvDataTable.Columns.Add(headings[i], typeof(string));
       } 
    }
    else //if no headers just go for col1, col2 etc.
    {
        for (int i = 0; i < headings.Length; i++)
        {
           //create arbitary column names
           csvDataTable.Columns.Add(”col”+(i+1).ToString(), typeof(string));
        }
    }
    
    //populate the DataTable
    for (int i = index; i < csvData.Length; i++)
    {
        //create new rows
        DataRow row = csvDataTable.NewRow();
    
        for (int j = 0; j < headings.Length; j++)
        {
             //fill them
             row[j] = csvData[i].Split(’,')[j];
        }
    
        //add rows to over DataTable
        csvDataTable.Rows.Add(row);
    }
    
    //return the CSV DataTable
    return csvDataTable;
    
    } 
