       public DataSet query_iseries(string datasource, string query, string[] parameterName, string[] parameterValue)
        {
            try
            {
                // Open a new stream connection to the iSeries
                using (var iseries_connection = new OleDbConnection(datasource))
                {
                    // Create a new command
                    OleDbCommand command = new OleDbCommand(query, iseries_connection);
                    // Bind parameters to command query
                    if (parameterName.Count() >= 1)
                    {
                        for (int i = 0; i < parameterName.Count(); i++)
                        {
                            command.Parameters.AddWithValue("@" + parameterName[i], parameterValue[i]);
                        }
                    }
                    // Open the connection
                    iseries_connection.Open();
                    // Create a DataSet to hold the data
                    DataSet iseries_data = new DataSet();
                    // Create a data adapter to hold results of the executed command
                    using (OleDbDataAdapter data_adapter = new OleDbDataAdapter(command))
                    {
                        // Fill the data set with the results of the data adapter
                        data_adapter.Fill(iseries_data);
                    }
                    return iseries_data;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
