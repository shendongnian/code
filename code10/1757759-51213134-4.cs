      try
                {
    
                    saveFileDialog1.Title = "Save as Excel File";
                    saveFileDialog1.FileName = "";
                    saveFileDialog1.Filter = "Excel Files(2003)|*.xls|Excel Files(2007)|*.xls";
                    if (saveFileDialog1.ShowDialog() != DialogResult.Cancel)
                    {
                        Microsoft.Office.Interop.Excel.Application worksheet = new Microsoft.Office.Interop.Excel.Application();
                        worksheet.Application.Workbooks.Add(Type.Missing);
                        worksheet.Columns.ColumnWidth = 20;
                        for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                        {
                            worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
    
                        }
                        for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                        {
                            for (int j = 0; j < dataGridView1.Columns.Count; j++)
                            {
                                worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                            }
    
                        }
                        worksheet.ActiveWorkbook.SaveCopyAs(saveFileDialog1.FileName.ToString());
                        worksheet.ActiveWorkbook.Saved = true;
                        worksheet.Quit();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
