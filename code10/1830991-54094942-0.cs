    //---------------------------------------------------------String Tool 2-----------------------------------------------------
    public static class StringTool2
    {
        /// <summary>
        /// Get a substring of the first N characters.
        /// </summary>
        // First possible truncate method
        public static string Truncate(string source, int length)
        {
            if (source.Length > length)
            {
                source = source.Substring(0, length);
            }
            return source;
        }
        /// <summary>
        /// Get a substring of the first N characters. [Slow]
        /// </summary>
        // Second possible truncate method
        public static string Truncate2(string source, int length)
        {
            return source.Substring(0, Math.Min(length, source.Length));
        }
        // Method to export (Datatable) to csv
        public static void ToCSV2(this DataTable dtDataTable, string strFilePath)
        {
            StreamWriter sw = new StreamWriter(strFilePath, false);
            //Datatable generation
            for (int i = 0; i < dtDataTable.Columns.Count; i++)
            {
                //Create comma separated values, retrieving from datatable
                sw.Write(dtDataTable.Columns[i]);
                if (i < dtDataTable.Columns.Count - 1)
                {
                    sw.Write(",");
                }
            }
            sw.Write(sw.NewLine);
            // Foreach row in the DataTable
            foreach (DataRow account in dtDataTable.Rows)
            {
                for (int i = 0; i < dtDataTable.Columns.Count; i++)
                {
                    if (!Convert.IsDBNull(account[i]))
                    {
                        string value = account[i].ToString();
                        if (value.Contains(','))
                        {
                            value = String.Format("\"{0}\"", value);
                            sw.Write(value);
                        }
                        else
                        {
                            sw.Write(account[i].ToString());
                        }
                    }
                    if (i < dtDataTable.Columns.Count - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }
    }
    //----------------------------------------------------------------------------------------------------------------------------------
