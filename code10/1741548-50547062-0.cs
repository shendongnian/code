    public bool Update(ClientiClass c)
    {
        bool isSuccess = false;
        SqlConnection conn = new SqlConnection(mycon);
        try
        {
            string sql = "UPDATE Clienti SET Nume=@Nume, Tara=@Tara, Judet=@Judet, Telefon=@Telefon, Mail=@Mail, CNP=@CNP  WHERE CodClient=@CodClient";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Nume", c.NumePrenume);
            cmd.Parameters.AddWithValue("@Tara", c.Tara);
            cmd.Parameters.AddWithValue("@Judet", c.Judet);
            cmd.Parameters.AddWithValue("@Telefon", c.Telefon);
            cmd.Parameters.AddWithValue("@Mail", c.EMail);
            cmd.Parameters.AddWithValue("@CNP", c.CNP);
            // Change c.CodClient for the right field if it's not named like this.
            cmd.Parameters.AddWithValue("@CodClient", c.CodClient);
            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            if(rows>0)
            {
                isSuccess = true;
            }
            else
            {
                isSuccess = false;
            }
        }
        catch (Exception ex)
        {
        }
        finally
        {
            conn.Close();
        }
        return isSuccess;
    }
