    //...
    using (var comm = new SQLiteCommand($"SELECT * FROM {tableName}", conn))
    {
        using (var reader = comm.ExecuteReader())
        {
            var dt = d.Tables[tableName];
            while (reader.Read())
            {
                var r = dt.NewRow();
                for (var i = 0; i < dt.Columns.Count; i++)
                    try
                    {
                        var val = reader.GetValue(i);
                        r[i] = val;
                    }
                    catch (FormatException)
                    {
                        if (dt.Columns[i].DataType == typeof(DateTime))
                            r[i] = DateTime.MinValue;
                        else
                            throw;
                    }
                dt.Rows.Add(r);
            }
        }
    }
