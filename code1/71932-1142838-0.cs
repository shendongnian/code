    using (var connection = new SqlCeConnection(connectionString))
    {
        connection.Open();
        var nodeItem = rssDoc.SelectNodes("/edno23/posts/post");
        foreach (XmlNode xn in nodeItem)
        {
            using (
                var selectCommand =
                    new SqlCeCommand(
                        "Select * FROM posts Where hash=@endhash",
                        connection))
            {
                var msgText = xn["message"].InnerText;
                var c = xn["user_from"].InnerText;
                var avatar = xn["user_from_avatar"].InnerText;
                var endhash = GetMd5Sum(msgText);
                selectCommand.Parameters.Add("@endhash", endhash);
                selectCommand.CommandText =
                    "Select * FROM posts Where hash=@endhash";
                using (var reader = selectCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var msgs = reader["hash"].ToString();
                        if (msgs == endhash && msgs != null)
                        {
                            continue;
                        }
                        const string COMMAND_TEXT =
                            "INSERT INTO posts([user],msg,avatar,[date],hash) VALUES(@username,@messige,@userpic,@thedate,@hash)";
                        using (
                            var insertCommand =
                                new SqlCeCommand(
                                    COMMAND_TEXT, connection))
                        {
                            insertCommand.Parameters.Add("@username", c);
                            insertCommand.Parameters.Add(
                                "@messige", msgText);
                            insertCommand.Parameters.Add(
                                "@userpic", avatar);
                            insertCommand.Parameters.Add("@thedate", dt);
                            insertCommand.Parameters.Add(
                                "@hash", endhash);
                            insertCommand.ExecuteNonQuery();
                                // executes query
                        }
                        adapter.Update(data); // saves teh changes
                    }
                    reader.Close();
                }
            }
        }
        connection.Close();
    }
