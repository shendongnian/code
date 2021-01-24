    var connectionSettings = ConfigurationManager.ConnectionStrings["Example"];
    var dbFactory = DbProviderFactories.GetFactory(connectionSettings.ProviderName);
    using (DbConnection connection = dbFactory.CreateConnection())
    using (DbCommand countCommand = connection.CreateCommand())
    {
        string sql = @"
    SELECT COUNT(*) 
    FROM database.tablename 
    WHERE artist=@artist AND title=@title 
    AND genre=@genre";
        countCommand.CommandText = sql;
        countCommand.Parameters.Add(GetParameter(dbFactory, "@artist", null));
        countCommand.Parameters.Add(GetParameter(dbFactory, "@title", null));
        countCommand.Parameters.Add(GetParameter(dbFactory, "@genre", null));
        for (int i = 0; i < songs.Length; i++)
        {
            var song = songs[i];
            countCommand.Parameters["@artist"].Value = song.artist;
            countCommand.Parameters["@title"].Value = song.title;
            countCommand.Parameters["@genre"].Value = song.genre;
            int matches = (int)countCommand.ExecuteScalar();
            if (matches == 0)
                continue;
            using (DbCommand insertCommand = dbFactory.CreateCommand())
            {
                string insertSql = @"
    INSERT INTO database.tablename(artist, title, length, genre) 
    VALUES(@artist, @title, @length, @genre)";
                insertCommand.CommandText = insertSql;
                insertCommand.Parameters.Add(GetParameter(dbFactory, "@artist", song.artist));
                insertCommand.Parameters.Add(GetParameter(dbFactory, "@title", song.title));
                insertCommand.Parameters.Add(GetParameter(dbFactory, "@length", song.length));
                insertCommand.Parameters.Add(GetParameter(dbFactory, "@genre", song.genre));
                int result = insertCommand.ExecuteNonQuery();
            }
        }
    }
