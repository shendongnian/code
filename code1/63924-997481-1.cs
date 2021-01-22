    System.Text.StringBuilder builder = new System.Text.StringBuilder();
    
    foreach(DataRow row in dataSet.Tables[0].Rows)
    {
        builder.Append(row["name"].ToString());
    }
    
    string finalName = builder.ToString();
