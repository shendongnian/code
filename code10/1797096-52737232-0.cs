    while (rdr.Read())
    {
        DateTime date = rdr.GetDateTime("Month"); 
        string getMonth = date.ToString("MMM");
    }
