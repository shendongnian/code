    public static string CountTblColumByValue(string columnName, string value)
    {
        String cs = ConfigurationManager.ConnectionStrings["BD_CompanyConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(cs))
        {
            string sqlQuery ="Select Count(@myColumName) from tblAttendance1 where @myColumName = @myValue ";
            using(SqlCommand cmd = new SqlCommand(sqlQuery, con))
            {
               con.Open();
               cmd.Parameters.AddWithValue("@myColumName", columnName);
               cmd.Parameters.AddWithValue("@myValue", value);
               object count = cmd.ExecuteScalar();
               
               return count.ToString();
            }
        }
    }
