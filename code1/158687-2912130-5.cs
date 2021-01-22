    using (var Conn = new SqlConnection(_ConnectionString))
    {
        try
        {
            Conn.Open();
            using (var ts = new System.Transactions.TransactionScope())
            {
                using (SqlCommand Com = new SqlCommand(ComText, Conn))
                {
                    /* DB work */
                }
                ts.Complete();
            }
        }
        catch (Exception Ex)
        {     
            return -1;
        }
    }
