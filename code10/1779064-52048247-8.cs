    var connectionSettings = ConfigurationManager.ConnectionStrings["Example"];
    var dbFactory = DbProviderFactories.GetFactory(connectionSettings.ProviderName);
    using (DbConnection connection = dbFactory.CreateConnection(connectionSettings.ConnectionString))
    using (DbCommand countCommand = connection.CreateCommand())
    {
        string sql = @"
    SELECT COUNT(*) 
    FROM database.tablename 
    WHERE artist=@artist AND title=@title 
    AND genre=@genre";
        countCommand.CommandText = sql;
        countCommand.Parameters.Add(dbFactory.GetParameter("@artist", null));
        countCommand.Parameters.Add(dbFactory.GetParameter("@title", null));
        countCommand.Parameters.Add(dbFactory.GetParameter("@genre", null));
        for (int i = 0; i < songs.Length; i++)
        {
            var song = songs[i];
            countCommand.Parameters["@artist"].Value = song.artist;
            countCommand.Parameters["@title"].Value = song.title;
            countCommand.Parameters["@genre"].Value = song.genre;
            int matches = (int)countCommand.ExecuteScalar();
            if (matches == 0)
                continue;
            using (DbCommand insertCommand = connection.CreateCommand())
            {
                string insertSql = @"
    INSERT INTO database.tablename(artist, title, length, genre) 
    VALUES(@artist, @title, @length, @genre";
                insertCommand.CommandText = insertSql;
                insertCommand.Parameters.Add(dbFactory.GetParameter("@artist", song.artist));
                insertCommand.Parameters.Add(dbFactory.GetParameter("@title", song.title));
                insertCommand.Parameters.Add(dbFactory.GetParameter("@length", song.length));
                insertCommand.Parameters.Add(dbFactory.GetParameter("@genre", song.genre));
                int result = insertCommand.ExecuteNonQuery();
            }
        }
    }
