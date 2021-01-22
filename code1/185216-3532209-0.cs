            /// <summary>
        /// Generates the contents of the log file.
        /// </summary>
        /// <returns>The contents of the log file.</returns>
        internal string GenerateLogFile()
        {
            StringBuilder csvExport = new StringBuilder();
            csvExport.AppendLine(Resources.CSVHeader);
            foreach (DataRow row in this.logEntries.Rows)
            {
                csvExport.AppendLine(
                    string.Format(
                    "\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\", \"{9}\"",
                    row[ColumnNames.LogTime], row[ColumnNames.Field1], row[ColumnNames.Field2], row[ColumnNames.Field3], row[ColumnNames.Field4], row[ColumnNames.Field5], row[ColumnNames.Field6], row[ColumnNames.Field7], row[ColumnNames.Field8], row[ColumnNames.Field9]));
            }
            return csvExport.ToString();
        }
        /// <summary>
        /// Adds the CSV file to the response.
        /// </summary>
        /// <param name="csvExportContents">The contents of the CSV file.</param>
        internal void DisplayLogFile(string csvExportContents)
        {
            byte[] data = new ASCIIEncoding().GetBytes(csvExportContents);
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "APPLICATION/OCTET-STREAM";
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=Export.csv");
            HttpContext.Current.Response.OutputStream.Write(data, 0, data.Length);
            HttpContext.Current.Response.End();
        }
