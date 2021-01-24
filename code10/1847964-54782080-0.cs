 Excel.Application Appl = null;
            Workbook opennwb = null;
            Worksheet wss = null;
            Workbooks opennwbs = null;
            // Save the whole row
            try
            {
                Appl = new Excel.Application();
                opennwbs = Appl.Workbooks;
                opennwb = opennwbs.Open(path,
                   Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                   Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                   Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                wss = opennwb.Worksheets[DateTime.Now.ToString("MM-dd-yy").ToString()];
                // Get the count of row and column
                int rows = wss.UsedRange.Rows.Count;
                int columns = 1;
                // Traverse all data
                for (int row = 1; row <= rows; row++)
                {
                    for (int column = 1; column <= columns; column++)
                    {
                        string temp = ((Range)wss.Cells[row, column]).Text.ToString();
                        // If true, get the correspond row
                        if (barcode == temp)
                        {
                            usedrow = row;
                            
                        }
                    }
                }
                
                return usedrow;
            }
            finally
            {
                //MessageBox.Show("about to quit query excel");
                //release all memory - stop EXCEL.exe from hanging around.
                if (opennwb != null) { opennwb.Close(); Marshal.FinalReleaseComObject(opennwb); opennwb = null; } //release each workbook like this
                if (wss != null) { Marshal.FinalReleaseComObject(wss); wss = null; } //release each worksheet like this
                if (opennwbs != null) { opennwbs.Close(); Marshal.FinalReleaseComObject(opennwbs); opennwbs = null; }
                if (Appl != null) { Appl.Quit(); Marshal.FinalReleaseComObject(Appl); Appl = null; } //release the Excel application 
                GC.Collect();
                //MessageBox.Show("Query closed");
