    private void btnExportAllToExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
    
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "StockReport(ALL)_" + DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string path = Path.GetFullPath(sfd.FileName);
                Cursor = Cursors.WaitCursor; // change cursor to hourglass type
                object misValue = System.Reflection.Missing.Value;
                Microsoft.Office.Interop.Excel.Application xlexcel = new Microsoft.Office.Interop.Excel.Application();
                xlexcel.PrintCommunication = false;
                xlexcel.ScreenUpdating = false;
                xlexcel.DisplayAlerts = false; // Without this you will get two confirm overwrite prompts
                Workbook xlWorkBook = xlexcel.Workbooks.Add(misValue);
                //Save the excel file under the captured location from the SaveFileDialog
                xlWorkBook.SaveAs(sfd.FileName, 
                    XlFileFormat.xlWorkbookNormal, 
                    misValue, misValue, misValue, misValue, 
                    XlSaveAsAccessMode.xlExclusive, 
                    misValue, misValue, misValue, misValue, misValue);
     
                insertDataToSheet(path,sfd.FileName);
                xlexcel.DisplayAlerts = true;
                xlWorkBook.Close(true, misValue, misValue);
                xlexcel.Quit();
                releaseObject(xlWorkBook);
                releaseObject(xlexcel);
                // Clear Clipboard and DataGridView selection
                Clipboard.Clear();
                dgvStockReport.ClearSelection();
            }
        }
