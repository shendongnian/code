        /// <summary>
        /// Converts the passed in data table to a CSV-style string.      
        /// </summary>
        /// <param name="table">Table to convert</param>
        /// <returns>Resulting CSV-style string</returns>
        public static string ToCSV(this DataTable table)
        {
            return ToCSV(table, ",", true);
        }
        /// <summary>
        /// Converts the passed in data table to a CSV-style string.
        /// </summary>
        /// <param name="table">Table to convert</param>
        /// <param name="includeHeader">true - include headers<br/>
        /// false - do not include header column</param>
        /// <returns>Resulting CSV-style string</returns>
        public static string ToCSV(this DataTable table, bool includeHeader)
        {
            return ToCSV(table, ",", includeHeader);
        }
        /// <summary>
        /// Converts the passed in data table to a CSV-style string.
        /// </summary>
        /// <param name="table">Table to convert</param>
        /// <param name="includeHeader">true - include headers<br/>
        /// false - do not include header column</param>
        /// <returns>Resulting CSV-style string</returns>
         public static string ToCSV(this DataTable table, string delimiter, bool includeHeader)
        {
            var result = new StringBuilder();
 
            if (includeHeader)
            {
                foreach (DataColumn column in table.Columns)
                {
                    result.Append(column.ColumnName);
                    result.Append(delimiter);
                }
 
                result.Remove(--result.Length, 0);
                result.Append(Environment.NewLine);
            }
 
            foreach (DataRow row in table.Rows)
            {
                foreach (object item in row.ItemArray)
                {
                    if (item is DBNull)
                        result.Append(delimiter);
                    else
                    {
                        string itemAsString = item.ToString();
                        // Double up all embedded double quotes
                        itemAsString = itemAsString.Replace("\"", "\"\"");
 
                        // To keep things simple, always delimit with double-quotes
                        // so we don't have to determine in which cases they're necessary
                        // and which cases they're not.
                        itemAsString = "\"" + itemAsString + "\"";
 
                        result.Append(itemAsString + delimiter);
                    }
                }
 
                result.Remove(--result.Length, 0);
                result.Append(Environment.NewLine);
            }
 
            return result.ToString();
        }
