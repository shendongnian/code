    public void MakeMyCSV(string MyFileName, SQLDataReader DataToOutput) 
    {
        MakeMyCSV(MyFileName, DataToOutput, null);
    }
    
    public void MakeMyCSV(string MyFileName, SQLDataReader DataToOutput, int[] ExcludedColumns) //if this is your current method signature...
    {
        //iterate through each record
        //    iterate through each column
        //        if ExcludedColumns is not null then see if this column is in it
        //            if it is not in it, output it
    }
