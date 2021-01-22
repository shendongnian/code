    private bool IsTableExisting(string table)
        {
            string command = $"select * from sys.tables";
            using (SqlConnection con = new SqlConnection(Constr))
            using (SqlCommand com = new SqlCommand(command, con))
            {
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.GetString(0).ToLower() == table.ToLower())
                        return true;
                }
                reader.Close();
            }
            return false;
        }
