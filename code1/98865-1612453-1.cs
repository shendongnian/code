    using (SqlCeConnection cn = new SqlCeConnection(yourConnectionString))
    {
        if (cn.State == ConnectionState.Closed)
            cn.Open();
        using (SqlCeCommand cmd = new SqlCeCommand())
        {
            cmd.Connection = cn;
            cmd.CommandText = "YourTableName";
            cmd.CommandType = CommandType.TableDirect;
            using (SqlCeResultSet rs = cmd.ExecuteResultSet(ResultSetOptions.Updatable | ResultSetOptions.Scrollable))
            {
                SqlCeUpdatableRecord record = rs.CreateRecord();
                using (var sr = new System.IO.StreamReader(yourConnectionString))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        int index = 0;
                        string[] values = line.Split('\t');
                        //write these lines as many times as the number of columns in the table...
                        record.SetValue(index, values[index++] == "NULL" ? null : values[index - 1]);
                        record.SetValue(index, values[index++] == "NULL" ? null : values[index - 1]);
                        record.SetValue(index, values[index++] == "NULL" ? null : values[index - 1]);
                        rs.Insert(record);
                    }
                }
            }
        }
    }
