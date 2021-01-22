    DataTable dt = new DataTable();
    dt = dsData.Tables[0].Clone();
    DataRows[] drResults = dsData.Tables[0].Select("ColName = 'criteria');
    
    foreach(DataRow dr in drResults)
    {
        object[] row = dr.ItemArray;
        dt.Rows.Add(row);
    } 
