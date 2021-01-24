    using (var conn = new SqlConnection(this.connString))
    {
        using (var comm = new SqlCommand(DatabaseLayer.procSendEmail, conn) { CommandType = CommandType.StoredProcedure })
        {
            comm.Parameters.Add(new SqlParameter("@IsTemplate", SqlDbType.TinyInt));
            comm.Parameters.Add(new SqlParameter("@DateInsertKey", SqlDbType.Int));
            comm.Parameters.Add(new SqlParameter("@EmailTO", SqlDbType.NVarChar, 1000));
            comm.Parameters.Add(new SqlParameter("@EmailBody", SqlDbType.NVarChar, -1));
            comm.Parameters.Add(new SqlParameter("@EmailImportance", SqlDbType.TinyInt));
            comm.Parameters.Add(new SqlParameter("@EmailSubject", SqlDbType.NVarChar, 1000));
            comm.Parameters.Add(new SqlParameter("@Success", SqlDbType.Bit) { Direction = ParameterDirection.Output });
        }
    }
