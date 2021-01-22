    public void Something(DataTable dt)
    {
        var data = from row in dt.AsEnumerable()
                   select new { 
                                Order = row["Order"].ToString(), 
                                Something = row["Something"].ToString(),
                                Customer = row["Customer"].ToString(),
                                Address = row["Address"].ToString()
                              };
    }
