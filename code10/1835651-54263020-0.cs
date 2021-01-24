    public static SearchModel GetSearchResults(SearchModel model)
    {
        List<ResultModel> results = new List<ResultModel>();
        SqlCommand cmd = new SqlCommand(); // only for compile for finnaly dispose
        try
        {
            using (SqlConnection conn = new SqlConnection("connection string"))
            {
                conn.Open();
                string sqlCommand = string.Empty;
                switch (model.Attribute)
                {
                    case "Users":
                        cmd = AdoBase.GetSqlCommand("GeneralUserSearch", conn);
                        if (!string.IsNullOrWhiteSpace(model.Name)) {
                            cmd.Parameters.AddWithValue("Name", model.Name);
                        }
                        if (!string.IsNullOrWhiteSpace(model.Name)) { // redundant if or mistake, and there should be model.Username
                            cmd.Parameters.AddWithValue("Username", model.Username);
                        }
                        break;
                    case "Favorites":
                        cmd = AdoBase.GetSqlCommand("UserFavorites", conn);
                        cmd.Parameters.AddWithValue("Favorites", model.Favorites);
                        break;
                    case "Email":
                        cmd = AdoBase.GetSqlCommand("EmailSearch", conn);
                        cmd.Parameters.AddWithValue("Email", model.Email);
                        break;
                }
                SimpleMethod(results, cmd, model);
            }
        }
        catch (Exception ex)
        {
            return ex;
        }
        finally
        {
            cmd.Dispose();
        }
        return model;
    }
