    using (System.Data.IDataReader IReader = ICommand.ExecuteReader())
    {
        if (((System.Data.Common.DbDataReader)IReader).HasRows)
        {
            //do stuff
        }
    } // End Using IReader 
