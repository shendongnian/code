    public static IEnumerable<User> Find(Predicate<User> match)
    {
        //I'm not sure of the name
        using (var cn = new NpgsqlConnection("..your connection string..") )
        using (var cmd = new NpgsqlCommand("SELECT * FROM Users", cn))
        using (var rdr = cmd.ExecuteReader())
        {
            while (rdr.Read())
            {
               var user = BuildUserObjectFromIDataRecord(rdr);
               if (match(user)) yield return user;
            }
        }
    }
              
