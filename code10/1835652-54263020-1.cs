    public static void SimpleMethod(List<ResultModel> results, SqlCommand cmd, SearchModel model)
    {
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ResultModel result = new ResultModel();
                    switch (model.Attribute)
                    {
                        case "Users":
                            result.Users.Add(reader["User"]);
                            break;
                        case "Favorites":
                            result.User = reader["User"];
                            result.Favorites = reader["Favorites"];
                            break;
                        case "Email":
                            result.User = reader["User"];
                            result.Email = reader["Email"];
                            break;
                    }
                    results.Add(result);
                }
            }
        }
    }
