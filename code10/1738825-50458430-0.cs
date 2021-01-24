    using (var con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Checksheets.accdb;"))
    {
        using (var command = new OleDbCommand(query, con))
        {
            con.Open();
            using (var reader = command.ExecuteReader())
            {
                // Only single result set, use 'Read' here
                while (reader.Read())
                {
                    sheets.Add(new FabChecksheet
                    {
                        OrderNum = reader.GetString(0),
                        PartNum = reader.GetString(1)
                    });
                }
            }
        }
    }
