    SqlDataReader dr = cmd.ExecuteReader (CommandBehavior.SequentialAccess);
    if (!dr.HasRows) {
        // ...
    }
    while (dr.Read ()) {
        string name = dr.GetString (0);
        // ...
    }
