    var connectionString = ConfigurationManager.ConnectionStrings["SomeCN"].ConnectionString;
    using (var cn = new SqlConnection(connectionString))
    using (var cmd = cn.CreateCommand())
    {
        cn.Open();
        cmd.CommandText = "select imageid from accounts where accountid = @accountid";
        cmd.Parameters.AddWithValue("@accountid", 5);
        using (var reader = cmd.ExecuteReader())
        {
            if (reader.Read())
            {
                var filePath = reader.GetString(0);
                // For this to work images must be stored inside the web application.
                // filePath must be a relative location inside the virtual directory
                // hosting the application. Depending on your environment some
                // transformations might be necessary on filePath before assigning it
                // to the image url.
                imageControl.ImageUrl = filePath;
            }
        }
    }
