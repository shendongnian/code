    cmd.Parameters.AddWithValue("@name", string.IsNullOrEmpty(name) ?
        System.Data.SqlTypes.SqlString.Null : name);
    cmd.Parameters.AddWithValue("@lastname", string.IsNullOrEmpty(lastname) ?
        System.Data.SqlTypes.SqlString.Null : lastname);
    cmd.Parameters.AddWithValue("@pass", string.IsNullOrEmpty(pass) ?
        System.Data.SqlTypes.SqlString.Null : pass);
