        public static void ConvertDtTableToCSV(DataTable dt, string filePath)
        {
            string tempPath = System.IO.Path.GetTempPath();
            using (var sw = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                var columnNames = dt.Columns.Cast<DataColumn>().Select(column => column.ColumnName);
                sw.WriteLine(string.Join(",", columnNames));
                foreach (DataRow row in dt.Rows)
                {
                    IEnumerable<string> fields = row.ItemArray.Select(field => /*string.Concat("\"", */field.ToString()/*.Replace("\"", "\"\""), "\"")*/);
                    sw.WriteLine(string.Join(",", fields));
                }
                sw.Flush();
            }
        }
