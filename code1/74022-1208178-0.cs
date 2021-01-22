    if(!string.IsNullOrEmpty(DataRowObject["name"].ToString()))
    {
    string name = (string)DataRowObject["name"];
    }
    else
    {
    //i.e Write error to the log file
    string error = "The database table has a null value";
    
    }
