    DataTable dt = SmoApplication.EnumAvailableSqlServers(false);
    if (dt.Rows.Count > 0)
    {
        foreach (DataRow dr in dt.Rows)
        {
            Console.WriteLine(dr["Name"]);
        }
    }
     
 
