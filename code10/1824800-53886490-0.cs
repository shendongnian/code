            Excel.Application oXL;
            Excel._Workbook oWB;
            Excel._Worksheet oSheet;
            try
            {
                //Start Excel and get Application object.
                oXL = new Microsoft.Office.Interop.Excel.Application();
                //Get a new workbook.
                oWB = oXL.Workbooks.Open("C:\\Users\\User\\Test.xlsx");
                //Specify different sheet names
                oSheet = oXL.Worksheets["Vehicles"];
                //Define last row
                int _lastRow = oSheet.Range["B" + oSheet.Rows.Count].End[Excel.XlDirection.xlUp].Row+1;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 1; j < dataGridView1.Columns.Count; j++)
                    {
                        oSheet.Cells[_lastRow, j+1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                    _lastRow++;
                }
                //Make sure Excel open and give the user control of Microsoft Excel's lifetime.
                oXL.Visible = true;
                oXL.UserControl = true;
                //Autosave excel file
                oWB.Save();
                Marshal.ReleaseComObject(oXL);
            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);
                MessageBox.Show(errorMessage, "Error");
            }
        }
