    public static DataTable ImportCSV(string fullPath, string[] sepString)
        {
            DataTable dt = new DataTable();
            using (StreamReader sr = new StreamReader(fullPath))
            {
               //stream uses using statement because it implements iDisposable
                string firstLine = sr.ReadLine();
                var headers = firstLine.Split(sepString, StringSplitOptions.None);
                foreach (var header in headers)
                {
                   //create column headers
                    dt.Columns.Add(header);
                }
                int columnInterval = headers.Count();
                string newLine = sr.ReadLine();
                while (newLine != null)
                {
                    //loop adds each row to the datatable
                    var fields = newLine.Split(sepString, StringSplitOptions.None); // csv delimiter    
                    var currentLength = fields.Count();
                    if (currentLength < columnInterval)
                    {
                        while (currentLength < columnInterval)
                        {
                           //if the count of items in the row is less than the column row go to next line until count matches column number total
                            newLine += sr.ReadLine();
                            currentLength = newLine.Split(sepString, StringSplitOptions.None).Count();
                        }
                        fields = newLine.Split(sepString, StringSplitOptions.None);
                    }
                    if (currentLength > columnInterval)
                    {  
                        //ideally never executes - but if csv row has too many separators, line is skipped
                        newLine = sr.ReadLine();
                        continue;
                    }
                    dt.Rows.Add(fields);
                    newLine = sr.ReadLine();
                }
                sr.Close();
            }
            return dt;
        }
