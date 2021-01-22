    public static bool ExecuteSql(string sqlScript)
    {
        bool success = true;
        using (SqlConnection cn = new SqlConnection([YourConnectionString]))
        {
            SqlCommand cmd = null;
            try
            {
                cn.Open();
                string[] commands = sqlScript.Split(new string[] { "GO\r\n", "GO ", "GO\t" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string c in commands)
                {
                    cmd = new SqlCommand(c, cn);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                success = false;
                throw new Exception("Failed to execute sql.", ex);
            }
            finally
            {
                cn.Close();
            }
            return success;
        }
    }
