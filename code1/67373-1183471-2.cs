    /// <summary>
    /// Simple class for reading delimited text files
    /// </summary>
    public class DelimitedTextReader
    {
        /// <summary>
        /// Read the file and return a DataTable
        /// </summary>
        /// <param name="filename">File to read</param>
        /// <param name="delimiter">Delimiting string</param>
        /// <returns>Populated DataTable</returns>
        public static DataTable ReadFile(string filename, string delimiter)
        {
            return ReadFile(filename, delimiter, null);
        }
        /// <summary>
        /// Read the file and return a DataTable
        /// </summary>
        /// <param name="filename">File to read</param>
        /// <param name="delimiter">Delimiting string</param>
        /// <param name="columnNames">Array of column names</param>
        /// <returns>Populated DataTable</returns>
        public static DataTable ReadFile(string filename, string delimiter, string[] columnNames)
        {
            //  Create the new table
            DataTable data = new DataTable();
            data.Locale = System.Globalization.CultureInfo.CurrentCulture;
            //  Check file
            if (!File.Exists(filename))
                throw new FileNotFoundException("File not found", filename);
            //  Process the file line by line
            string line;
            using (TextReader tr = new StreamReader(filename, Encoding.Default))
            {
                //  If column names were not passed, we'll read them from the file
                if (columnNames == null)
                {
                    //  Get the first line
                    line = tr.ReadLine();
                    if (string.IsNullOrEmpty(line))
                        throw new IOException("Could not read column names from file.");
                    columnNames = line.Split(new string[] { delimiter }, StringSplitOptions.RemoveEmptyEntries);
                }
                //  Add the columns to the data table
                foreach (string colName in columnNames)
                    data.Columns.Add(colName);
                //  Read the file
                string[] columns;
                while ((line = tr.ReadLine()) != null)
                {
                    columns = line.Split(new string[] { delimiter }, StringSplitOptions.None);
                    //  Ensure we have the same number of columns
                    if (columns.Length != columnNames.Length)
                    {
                        string message = "Data row has {0} columns and {1} are defined by column names.";
                        throw new DataException(string.Format(message, columns.Length, columnNames.Length));
                    }
                    data.Rows.Add(columns);
                }
            }
            return data;
        }
    }
