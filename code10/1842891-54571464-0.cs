    int Value;
    bool IsInteger;
    foreach (DataRow row in dt.Rows)
    {  
    IsInteger = int.TryParse(row["columnname"].ToString(), out Value);
    
    if(!IsInteger)
    {
    }
    }
