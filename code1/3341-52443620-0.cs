    public static void ExecuteSqlScript(this SqlConnection sqlConnection, string sqlBatch)
            {
                // Handle backslash utility statement (see http://technet.microsoft.com/en-us/library/dd207007.aspx)
                sqlBatch = Regex.Replace(sqlBatch, @"\\(\r\n|\r|\n)", string.Empty);
    
                // Handle batch splitting utility statement (see http://technet.microsoft.com/en-us/library/ms188037.aspx)
                var batches = Regex.Split(
                    sqlBatch,
                    string.Format(CultureInfo.InvariantCulture, @"^\s*({0}[ \t]+[0-9]+|{0})(?:\s+|$)", BatchTerminator),
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
    
                for (int i = 0; i < batches.Length; ++i)
                {
                    // Skip batches that merely contain the batch terminator
                    if (batches[i].StartsWith(BatchTerminator, StringComparison.OrdinalIgnoreCase) ||
                        (i == batches.Length - 1 && string.IsNullOrWhiteSpace(batches[i])))
                    {
                        continue;
                    }
    
                    // Include batch terminator if the next element is a batch terminator
                    if (batches.Length > i + 1 &&
                        batches[i + 1].StartsWith(BatchTerminator, StringComparison.OrdinalIgnoreCase))
                    {
                        int repeatCount = 1;
    
                        // Handle count parameter on the batch splitting utility statement
                        if (!string.Equals(batches[i + 1], BatchTerminator, StringComparison.OrdinalIgnoreCase))
                        {
                            repeatCount = int.Parse(Regex.Match(batches[i + 1], @"([0-9]+)").Value, CultureInfo.InvariantCulture);
                        }
    
                        for (int j = 0; j < repeatCount; ++j)
                        {
                           var command = sqlConnection.CreateCommand();
                           command.CommandText = batches[i];
                           command.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        var command = sqlConnection.CreateCommand();
                        command.CommandText = batches[i];
                        command.ExecuteNonQuery();
                    }
                }
            }
 
