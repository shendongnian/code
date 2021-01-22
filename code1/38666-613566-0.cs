    SubSonic.Query qry = new SubSonic.Query(Usr.Schema);
    qry.SetSelectList(Usr.Columns.UserPkid);
    qry.QueryType = SubSonic.QueryType.Select;
    qry.AddWhere(Usr.UsernameColumn.ColumnName, SubSonic.Comparison.Equals, Username);
    
    using (IDataReader reader = qry.ExecuteReader())
    {
        while (reader.Read())
        {
            Trace.WriteLine("Fetched User Pkid [" + reader[Usr.Columns.UserPkid].ToString() + "]");
        }
    }
