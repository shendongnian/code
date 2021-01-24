    private bool Delete(int id)
    {
        string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Parnian\\documents\\visual studio 2017\\Projects\\Bank\\Bank\\Database.mdf;Integrated Security=True";
        SqlConnection sqlConn = new SqlConnection(connString);
        String sql = "Delete FROM TblBank WHERE  Id =@id ";
        try
        {
            sqlConn.Open();
            SqlCommand cmd = new SqlCommand(sql, sqlConn);
            cmd.Parameters.AddWithValue("id", id);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();
            sql.Close();
            return true;
        }
        catch (Exception ex)
        {
            MessageBoxEx.Show(ex.Message, "wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }
