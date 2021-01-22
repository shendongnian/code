    public static DataTable ImportExcelXML(string Filename)
        {
            //create a new dataset to load in the XML file
            DataSet DS = new DataSet();
            //Read the XML file into the dataset
            DS.ReadXml(Filename);
            //Create a new datatable to store the raw Data
            DataTable Raw = new DataTable();
            //assign the raw data from the file to the datatable
            Raw = DS.Tables["Data"];
            //count the number of columns in the XML file
            int ColumnNumber = Raw.Columns.Count;
            //create a datatable to store formatted Import Data
            DataTable ImportData = new DataTable();
            //create a string list to store the cell data of each row
            List<string> RowData = new List<string>();
            //loop through each row in the raw data table
            for (int Counter = 0; Counter < Raw.Rows.Count; Counter++)
            {
                //if the data in the row is a colum header
                if (Counter < ColumnNumber)
                {
                    //add the column name to our formatted datatable
                    ImportData.Columns.Add(Raw.Rows[Counter].ItemArray.GetValue(1).ToString());
                }
                else
                {
                    //if the row # (1 row = 1 cell from the excel file) from the raw datatable is divisable evenly by the number of columns in the formated import datatable AND this is not the 1st row of the raw table data after the headers
                    if ((Counter % ColumnNumber == 0) && (Counter != ColumnNumber))
                    {
                        //add the row we just built to the formatted import datatable
                        ImportData.Rows.Add(GenerateRow(ImportData, RowData));
                        //clear rowdata list in preperation for the next row
                        RowData.Clear();
                    }
                    //add the current cell data value from the raw datatable to the string list of cell values for the next row to be added to the formatted input datatable
                    RowData.Add(Raw.Rows[Counter].ItemArray.GetValue(1).ToString());
                }
            }
            //add the final row
            ImportData.Rows.Add(GenerateRow(ImportData, RowData));
            return ImportData;
        }
        public static DataRow GenerateRow(DataTable ImportData, List<string> RowData)
        {
            //create a counter to keep track of the column position during row composition
            int ColumnPosition = 0;
            //make a new datarow based on the shema of the formated import datatable
            DataRow NewRow = ImportData.NewRow();
            //for each string cell value collected for the RowData list for this row
            foreach (string CellData in RowData)
            {
                //add the cell value to the new datarow
                NewRow[ImportData.Columns[ColumnPosition].ColumnName] = CellData;
                //incriment column position in the new row
                ColumnPosition++;
            }
            //return the generated row
            return NewRow;
        }
