    public string updateQuery(string table, IEnumerable<KeyValuePair<string, object>> values, string conditionField, object conditionValue)
    {
        try
        {
            StringBuilder cmd = new StringBuilder("UPDATE [" + table + "]\nSET ");
    
            string delimiter = "";
            foreach (KeyValuePair<string, object> item in values)
            {
               cmd.AppendFormat("{0}[{1}]=@{1}", delimiter, item.Key);
               delimiter = ",\n";
            }
            cmd.AppendFormat("\nWHERE [{0}]= @{0};", conditionField);
            command.CommandText = cmd.ToString();
    
            foreach (KeyValuePair<string, object> item in values)
            {
                command.Parameters.AddWithValue("@" + item.Key, (object)item.Value ?? DBNull.Value);
            }
            command.Parameters.AddWithValue("@" + conditionField, conditionValue);
    
            // you didn't show where the connection was created or opened
            command.ExecuteNonQuery();    
            connection.Close();
    
            return command.CommandText;
        }
    
        catch (Exception ex)
        {
            throw ex;
        }
    }
