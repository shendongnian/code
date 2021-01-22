    public void flush_DataTable(DataTable dt, string tableName)//my incoming DTs have a million or so each and slow down over time to nothing. This helps.
        {  int bufferSize = 10000;
            int bufferHigh = bufferSize;
            int lowBuffer = 0;
            if (dt.Rows.Count >= bufferSize)
            {  using (SqlConnection conn = getConn())
                {   conn.Open();
                    while (bufferHigh < dt.Rows.Count)
                    {
                        using (SqlBulkCopy s = new SqlBulkCopy(conn))
                        {   s.BulkCopyTimeout = 900;
                            s.DestinationTableName = tableName;
                            s.BatchSize = bufferSize;
                            s.EnableStreaming = true;
                            foreach (var column in dt.Columns)
                                s.ColumnMappings.Add(column.ToString(), column.ToString());
                            DataTable bufferedTable = dt.Clone();
                            for (int bu = lowBuffer; bu < bufferHigh; bu++)
                            {
                                bufferedTable.ImportRow(dt.Rows[bu]);
                            }
                            s.WriteToServer(bufferedTable);
                            if (bufferHigh == dt.Rows.Count)
                            {
                                break;
                            }
                            lowBuffer = bufferHigh;
                            bufferHigh += bufferSize;
                            if (bufferHigh > dt.Rows.Count)
                            {
                                bufferHigh = dt.Rows.Count;
                            }
                        }
                    }
                    conn.Close();
                }
            }
            else
            {
                flushDataTable(dt, tableName);//perofrm a non-buffered flush (could just as easily flush the buffer here bu I already had the other method 
            }
        }
