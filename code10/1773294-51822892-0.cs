    var myemployeex = new Dictionary<string, Object>();
    using (var cmd = new SQLiteCommand(...))
    using (var reader = cmd.ExecuteReader()) {
        // replace "if" with "while" to get multiple rows
        if (reader.Read()) {
            for (int i = 0; i < reader.FieldCount; i++)
                employeex.Add(reader.GetName(i), reader.GetValue(i));
                // replace GetValue with GetString if you really want strings
        }
    }
