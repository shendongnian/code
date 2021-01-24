    public static string GetCityName(int cityId)
    {
        string sql = "SELECT Name FROM City WHERE Id = @Id";
        using(var con = new SqlConnection("Insert Your Connection String"))
        {
            using(var cmd = new SqlCommand(sql, con))
            {
                con.Open();
                cmd.Parameters.Add("Id", SqlDbType.Int).Value = cityId;
                string name = (string) cmd.ExecuteScalar();
                return name;
            }
        }
    }
