    public static int InsertCarico(string _marca, string _modello, string _causale, int _qta)
    {
        int insert = 0;
        try
        {
            if (connection.State == ConnectionState.Closed) connection.Open();
            using (SqlCommand cmd = new SqlCommand("spINSERTCARICO", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.Add("@MARCA", SqlDbType.VarChar).Value = _marca;
                cmd.Parameters.Add("@MODELLO", SqlDbType.VarChar).Value = _modello;
                cmd.Parameters.Add("@QTA", SqlDbType.Int).Value = _qta;
                cmd.Parameters.Add("@OPERATORE", SqlDbType.VarChar).Value = System.Environment.UserName;
                cmd.Parameters.Add("@CAUSALE", SqlDbType.VarChar).Value = _causale;
                cmd.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return 0;
        }
    }
