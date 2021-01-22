    public static IEnumerable<string> GetColumnValues(string fileName, string columnName, string delimiter)
    {
        using (System.IO.StreamReader reader = new System.IO.StreamReader(fileName))
        {
            string[] delim = new string[] { delimiter };
            string[] columns = reader.ReadLine().Split(delim, StringSplitOptions.None);
            int column = -1;
            for (int i = 0; i < columns.Length; i++)
            {
                if (string.Compare(columns[i], columnName, true) == 0)
                {
                    column = i;
                    break;
                }
            }
            if (column == -1) throw new ArgumentException("The specified column could not be found.");
            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                string[] line = reader.ReadLine().Split(delim, StringSplitOptions.None);
                if (line.Length > column) yield return line[column];
            }
        }
    }
