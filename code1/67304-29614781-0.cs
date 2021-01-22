     private DataTable csvToDataTable(string fileName, char splitCharacter)
        {                
            StreamReader sr = new StreamReader(fileName);
            string myStringRow = sr.ReadLine();
            rows = myStringRow.Split(splitCharacter);
            DataTable CsvData = new DataTable();
            foreach (string column in rows)
            {
                //creates the columns of new datatable based on first row of csv
                CsvData.Columns.Add(column);
            }
            myStringRow = sr.ReadLine();
            while (myStringRow != null)
            {
                //runs until string reader returns null and adds rows to dt 
                rows = myStringRow.Split(splitCharacter);
                CsvData.Rows.Add(rows);
                myStringRow = sr.ReadLine();
            }
            return CsvData;
        }
