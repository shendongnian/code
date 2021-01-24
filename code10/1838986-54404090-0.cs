    using(var cmd = db.CreateCommand())
    {
        int index = 0;
        var sql = new StringBuilder("delete from [SomeTable] where [SomeId] in (");
        foreach(var item in items)
        {
            if (index != 0) sql.Append(',');
            var name = "@id_" + index++;
            sql.Append(name);
            cmd.Parameters.AddWithValue(name, item.SomeId);            
        }
        cmd.CommandText = sql.Append(");").ToString();
        cmd.ExecuteNonQuery();
    }
