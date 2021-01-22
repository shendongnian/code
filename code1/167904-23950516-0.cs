        private DataTable dataTable = null;
        private bool IsHeader = true;
        private string headerLine = string.Empty;
        private List<string> AllLines = new List<string>();
        private StringBuilder sb = new StringBuilder();
        private char seprateChar = ',';
        public DataTable ReadCSV(string path, bool IsReadHeader, char serparationChar)
        {
            seprateChar = serparationChar;
            IsHeader = IsReadHeader;
            using (StreamReader sr = new StreamReader(path,Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                  AllLines.Add( sr.ReadLine());
                }
                createTemplate(AllLines);
            }
            return dataTable;
        }
        public void WriteCSV(string path,DataTable dtable,char serparationChar)
        {
            AllLines = new List<string>();
            seprateChar = serparationChar;
            List<string> StableHeadrs = new List<string>();
            int colCount = 0;
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (DataColumn col in dtable.Columns)
                {
                    sb.Append(col.ColumnName);
                    if(dataTable.Columns.Count-1 > colCount)
                    sb.Append(seprateChar);
                    colCount++;
                }
                AllLines.Add(sb.ToString());
                
                for (int i = 0; i < dtable.Rows.Count; i++)
                {
                    sb.Clear();
                    for (int j = 0; j < dtable.Columns.Count; j++)
                    {
                        sb.Append(Convert.ToString(dtable.Rows[i][j]));
                        if (dataTable.Columns.Count - 1 > j)
                        sb.Append(seprateChar);
                    }
                    AllLines.Add(sb.ToString());
                }
                foreach (string dataline in AllLines)
                {
                    sw.WriteLine(dataline);
                }
            }
            
        }
        private DataTable createTemplate(List<string> lines)
        {
            
            List<string> headers = new List<string>();
            dataTable = new DataTable();
            if (lines.Count > 0)
            {
                string[] argHeaders = null;
                for (int i = 0; i < lines.Count; i++)
                {
                    if (i > 0)
                    {
                        DataRow newRow = dataTable.NewRow();
                        // others add to rows
                        string[] argLines = lines[i].Split(seprateChar);
                        for (int b = 0; b < argLines.Length; b++)
                        {
                            newRow[b] = argLines[b];
                        }
                        dataTable.Rows.Add(newRow);
                    }
                    else
                    {
                        // header add to columns
                        argHeaders = lines[0].Split(seprateChar);
                        foreach (string c in argHeaders)
                        {
                            DataColumn column = new DataColumn(c, typeof(string));
                            dataTable.Columns.Add(column);
                        }
                    }
                    
                }
               
            }
            return dataTable;
        }
    
