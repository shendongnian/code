    string nom = null, prenom = null;
    using (var cmd = connection.CreateCommand())
    {
        // create the command and bind the parameter; this prevents SQL injection
        cmd.CommandText = "SELECT nom, prenom from liste_personnels where mail = @mail";
        cmd.Parameters.AddWithValue("@mail", mailtest);
        using (var reader = cmd.ExecuteReader())
        {
            // check if a row was found in the DB; you may need to handle if it's false
            if (reader.Read())
            {
                // read the data
                nom = reader.GetString(0);
                prenom = reader.GetString(1);
            }
        }
    }
