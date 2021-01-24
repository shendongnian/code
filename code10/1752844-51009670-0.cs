    private void btnExcellExport_Click(object sender, EventArgs e)
        {
            if (!(dataGridView1.RowCount == 0))
            {
                if (backgroundWorker1.IsBusy)
                    return;
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", RestoreDirectory = true, InitialDirectory = HelpMeClass.ExcelSaveDirectory
                })
                {
                    
                    sfd.FileName = HelpMeClass.SearchString;
                    
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        HelpMeClass.ExcelSaveDirectory = Path.GetDirectoryName(sfd.FileName);
                        progressBar1.Show();
                        progressBar1.Minimum = 0;
                        progressBar1.Value = 0;
                        backgroundWorker1.RunWorkerAsync();
                       
                    }
                }
            }
            else
            {
                MessageBox.Show("Oops! Nothing to export!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Workbook wb = excel.Workbooks.Add(XlSheetType.xlWorksheet);
            Worksheet ws = (Worksheet)excel.ActiveSheet;
            excel.Visible = true;
            int index = 0;
            
            int process = dataGridView1.Rows.Count;
            int process1 = dataGridView2.Rows.Count;
            int process2 = dataGridView3.Rows.Count;
            ws.get_Range("A1", "C1").Merge(); // Merge columns for header
            ws.Cells[1, 1] = "Keyword: " + HelpMeClass.SearchString;
            ws.Cells[1, 1].Font.Bold = true; // Bold font in header
            if (!backgroundWorker1.CancellationPending)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    backgroundWorker1.ReportProgress(index++ * 100 / process);
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        ws.Cells[index + 1, 1] = cell.Value;
                    }
                }
                index = 0;
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    backgroundWorker1.ReportProgress(index++ * 100 / process1);
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        ws.Cells[index + 1, 2] = cell.Value;
                    }
                }
                index = 0;
                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    backgroundWorker1.ReportProgress(index++ * 100 / process2);
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        ws.Cells[index + 1, 3] = cell.Value;
                    }
                }
            }
            ws.Columns.AutoFit();
            try
            {
                ws.SaveAs(Path.Combine(HelpMeClass.ExcelSaveDirectory, HelpMeClass.SearchString), XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, false, false, XlSaveAsAccessMode.xlNoChange, XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing, Type.Missing);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ooops! I can`t access the file. Make sure the excel file is closed and try again. " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }
            //excel.Quit();
        }
