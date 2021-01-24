    public static DataTable GetDataTablefromCSV(string filePath)
            {
                try
                {
                    StreamReader _streamReader = new StreamReader(filePath);
                    string[] headers = _streamReader.ReadLine().Split(',');
                    DataTable dataTable = new DataTable();
                    foreach (string header in headers)
                    {
                        dataTable.Columns.Add(header);
                    }
                    while (!_streamReader.EndOfStream)
                    {
                        string[] rows = Regex.Split(_streamReader.ReadLine(), ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
                        DataRow dataRow = dataTable.NewRow();
                        for (int i = 0; i < headers.Length; i++)
                        {
                            dataRow[i] = rows[i];
                        }
                        dataTable.Rows.Add(dataRow);
                    }
                    return dataTable;
                }
                catch(Exception ex)
                {
                    return null;
                }            
            }
