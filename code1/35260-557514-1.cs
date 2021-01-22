    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection conn = new SqlConnection("Server=(local);Database=Test;UID=Scrap;PWD=password;");
            
            setAppRole(conn);
            conn.Close();
            setAppRole(conn);
            conn.Close();
        }
        static void setAppRole(SqlConnection conn) 
        {
            for (int i = 0; i < 2; i++)
            {
                conn.Open();
                try
                {
                    using (IDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "exec sp_setapprole ";
                        cmd.CommandText += string.Format("@rolename='{0}'", "MyAppRole");
                        cmd.CommandText += string.Format(",@password='{0}'", "password1");
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    if (i == 0 && ex.Number == 0)
                    {
                        conn.Close();
                        SqlConnection.ClearPool(conn);
                        continue;
                    }
                    else
                    {
                        throw;
                    }
                }
                return;
            }
        }
    }
