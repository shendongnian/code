    string SQL = "EXEC dbo.SaveResultsFromForm @NameValuePairAnswers = @NameValuePairAnswers";
                    SqlCommand InsertDataCommand = new SqlCommand(sSQL);
                    
                    
                    // now build out the namevalue pair paramater
                    SqlParameter TableData = new SqlParameter();
                    TableData.ParameterName = "@NameValuePairAnswers";
                    TableData.TypeName = "dbo.NameValuePairTable";
                    TableData.SqlDbType = SqlDbType.Structured;
                    TableData.Value = FormResultsDataTable;
    
                    // now add the tabledata to the list
                    InsertDataCommand.Parameters.Add(TableData);
                    
                    // to execute the command to SQL
                    InsertDataCommand.Execute()
