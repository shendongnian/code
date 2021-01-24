    public static string CountTblColumByValue(string columName,string value)
    {
        String cs = ConfigurationManager.ConnectionStrings["BD_CompanyConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(cs))
        {
            string sqlQuary ="Select Count(@myColumName) from tblAttendance1 where @myColumName = @myValue ";
            using(SqlCommand cmd = new SqlCommand(sqlQuary, con)){
               con.Open();
               cmd.Parameters.AddWithValue("@myColumName", columName);
               cmd.Parameters.AddWithValue("@myValue", value);
               object count=cmd.ExecuteScalar();
               return count.ToString();
            }
        }
    }
