     string[] headerColumns = header.Split(';'); // so i changed , to ;
                    foreach (string headerColumn in headerColumns)
                    {
                        CSVData.Columns.Add(headerColumn);
                    }
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        
                        if (string.IsNullOrEmpty(line)) continue;
                        string[] fields = line.Split(';'); // so i changed , to ;
                        DataRow importedRow = CSVData.NewRow();
