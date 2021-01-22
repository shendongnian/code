    void Foo(SqlCeConnection connection)
    {
        using (var cmd = new SqlCeCommand())
        {
            cmd.CommandType = CommandType.TableDirect;
            cmd.CommandText = "MyTableName";
            cmd.Connection = connection;
            using (var result = cmd.ExecuteResultSet(ResultSetOptions.Scrollable))
            {
                var record = result.CreateRecord();
                record.SetInt32(0, 1);
                // etc.
                result.Insert(record);
            }
        }
    }
