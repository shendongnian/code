    using(TransactionScope scope = ..)
    {
        using (SqlConnection conn = ..)
        using (SqlCommand command = ..)
        {
            conn.Open();
    
            SqlCommand.Execute(..);
        }
    
        using (SqlConnection conn = ..) // the same connection string
        using (SqlCommand command = ..)
        {
            conn.Open();
    
            SqlCommand.Execute(..);
        }
    
        scope.Complete();
    }
