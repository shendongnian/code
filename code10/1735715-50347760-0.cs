            Microsoft.Office.Interop.Excel.Application xlApp;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            xlApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
            xlWorkBook = xlApp.Workbooks.Add(Type.Missing);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            int i = 0;
            int j = 0;
            if (dgvSearchStudFees.Visible == true)
            {
                for (i = 0; i <= dgvSearchStudFees.RowCount - 1; i++)
                {
                    for (j = 0; j <= dgvSearchStudFees.ColumnCount - 1; j++)
                    {
                        DataGridViewCell cell = dgvSearchStudFees[j, i];
                        xlWorkSheet.Cells[i + 1, j + 1] = cell.Value;
                    }
                }
                var savefiledialog = new SaveFileDialog();
                savefiledialog.FileName = "Atharva ExcelSheet";
                savefiledialog.DefaultExt = ".xlsx";
                if (savefiledialog.ShowDialog() == DialogResult.OK)   // This should be == . "=" means assignment to left hand side
                {
                    xlWorkBook.SaveAs(savefiledialog.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                }
                xlApp.Quit();
            }
