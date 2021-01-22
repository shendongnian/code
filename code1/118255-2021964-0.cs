            //Just a test DataTable
            System.Data.DataTable table = new System.Data.DataTable();
            table.Columns.AddRange(new DataColumn[] { new DataColumn("Col1"),new DataColumn("Col2") });
            table.Rows.Add("row1col1", "row1col2");
            table.Rows.Add("row2col1", "row2col2");
            
            //create Excel Application
            Microsoft.Office.Interop.Excel.ApplicationClass s = new ApplicationClass();
            Workbook w = s.Workbooks.Add(""); //create new Workbook
            Worksheet ws = w.ActiveSheet as Worksheet;  //get active sheet.
            //COPY COLUMN HEADERS
            int startCol = 1;
            int startRow = 1;
            foreach (DataColumn col in table.Columns)
            {
                //copy columns in the first row
                ((Range)ws.Cells[startRow, startCol]).Value2 = col.ColumnName;
                startCol++;
            }
            //COPY ROWS
            startRow = 2; //start 2nd row
            foreach (DataRow row in table.Rows)
            {
                startCol = 1;
                foreach (DataColumn col in table.Columns)
                {
                    ((Range)ws.Cells[startRow, startCol]).Value2 = row[col].ToString();
                    startCol++;
                }
                startRow++;
            }
            
            //start EXCEL
            s.Visible = true;
