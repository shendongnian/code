            try
            {
                if (Conn.State == ConnectionState.Closed)
                    Conn.Open();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " : dbOperation.ExecuteNonQuery()");
            }
            finally
            {
                 if (Conn.State == ConnectionState.Open)
                    Conn.Closed();
            }
