    foreach(DataRow dr in dt.Rows)
    {
        DateTime date = new DateTime();
        foreach(string s in dic.Keys)
        {  
            switch(dic[s])
            {
                case "Month":
                    date.Month = dr[dic[s]];
                    break;
                case "Day":
                    date.Day = dr[dic[s]];
                    break;
                case "Year":
                    date.Year = dr[dic[s]];
                    break;
            }
        }
        // If valid date
        SqlParameter p = cmd.Parameters.AddWithValue("Date", date);
        p.SqlDbType = SqlDbType.DateTime;      
        
    }
