        using (IDataReader reader = cmd.ExecuteReader())
        {
            do
            {
                while (reader.Read())
                {
                    /* row */
                }
            } while (reader.NextResult()); /* grid */
        }
