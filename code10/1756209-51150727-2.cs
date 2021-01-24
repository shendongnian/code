    private string Method(string person)
    {
        string querySql ="SELECT [tools] FROM Equipment WHERE owner = @person"; 
        using (SqlCommand cmdSql = new SqlCommand(querySql, conObject))
        {
            cmdSql.Parameters.Add("@person", SqlDbType.VarChar).Value = person;
            using (SqlDataReader reader = cmdSql.ExecuteReader())
            {
                StringBuilder htmlBuilder = new StringBuilder();
                htmlBuilder.Append("<h2>"+ person +",</h2>");
                while (reader.Read())
                {
                    htmlBuilder.Append("<p>"+ reader[tools].ToString() +"</p><br />");
                }
            }
         }
         return htmlBuilder.ToString();
    }
