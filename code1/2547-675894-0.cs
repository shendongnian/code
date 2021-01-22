    DataRow row = ds.Tables[0].Rows[0];
    string value;
    
    if (row["fooColumn"] == DBNull.Value)
    {
       value = string.Empty;
    }
    else 
    {
       value = Convert.ToString(row["fooColumn"]);
    }
