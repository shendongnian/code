            Stopwatch sw = new Stopwatch();
            TimeSpan tsRead;
            TimeSpan tsTrunc;
            TimeSpan tsBcp;
            int rows;
            sw.Start();
            using (DataTable dt = DelimitedTextReader.ReadFile(textBox1.Text, "\t"))
            {
                tsRead = sw.Elapsed;
                sw.Reset();
                rows = dt.Rows.Count;
                string connect = @"Data Source=.;Initial Catalog=MyDB;Integrated Security=SSPI";
                using (SqlConnection cn = new SqlConnection(connect))
                using (SqlCommand cmd = new SqlCommand("TRUNCATE TABLE dbo.UploadTable", cn))
                using (SqlBulkCopy bcp = new SqlBulkCopy(cn))
                {
                    cn.Open();
                    sw.Start();
                    cmd.ExecuteNonQuery();
                    tsTrunc = sw.Elapsed;
                    sw.Reset();
                    sw.Start();
                    bcp.DestinationTableName = "dbo.UploadTable";
                    bcp.ColumnMappings.Add("Column A", "ColumnA");
                    bcp.ColumnMappings.Add("Column D", "ColumnD");
                    bcp.WriteToServer(dt);
                    tsBcp = sw.Elapsed;
                    sw.Reset();
                }
            }
            string message = "File read:\t{0}\r\nTruncate:\t{1}\r\nBcp:\t{2}\r\n\r\nTotal time:\t{3}\r\nTotal rows:\t{4}";
            MessageBox.Show(string.Format(message, tsRead, tsTrunc, tsBcp, tsRead + tsTrunc + tsBcp, rows));
