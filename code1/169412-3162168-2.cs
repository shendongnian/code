    void Foo(SqlCeConnection connection)
    {
        using (var cmd = new SqlCeCommand())
        {
            cmd.CommandType = CommandType.TableDirect;
            cmd.CommandText = "MyTableName";
            cmd.Connection = connection;
            cmd.IndexName = "PrimakryKeyIndexName";
            using (var result = cmd.ExecuteResultSet(
                                ResultSetOptions.Scrollable | ResultSetOptions.Updatable))
            {
                int pkValue = 100; // set this, obviously
                if (result.Seek(DbSeekOptions.FirstEqual, pkValue))
                {
                    // row exists, need to update
                    result.Read();
                    // set values
                    result.SetInt32(0, 1);
                    // etc. 
                    result.Update();
                }
                else
                {
                    // row doesn't exist, insert
                    var record = result.CreateRecord();
                    // set values
                    record.SetInt32(0, 1);
                    // etc. 
                    result.Insert(record);
                }
            }
        }
    } 
