        private void RemoveDuplicates(DataTable table1, string keyColumn)
    {
        Dictionary<string, string> uniquenessDict = new Dictionary<string, string>(table1.Rows.Count);
        StringBuilder sb = null;
        int rowIndex = 0;
        DataRow row;
        DataRowCollection rows = table1.Rows;
        while (rowIndex < rows.Count - 1)
        {
            row = rows[rowIndex];
            sb = new StringBuilder();
                sb.Append(((string)row[keyColumn]));
            
            if (uniquenessDict.ContainsKey(sb.ToString()))
            {
                rows.Remove(row);
                if (RemoveAllDupes)
                {
                    row = rows[rowIndex - 1];
                    rows.Remove(row);
                }
            }
            else
            {
                uniquenessDict.Add(sb.ToString(), string.Empty);
                rowIndex++;
            }
        }
    }
