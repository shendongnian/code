    using Microsoft.Office.Interop.Excel;
    using Application = Microsoft.Office.Interop.Excel.Application;
     var app = new Application();
     _Workbook workbook = app.Workbooks.Add(Type.Missing);
     app.Visible = false;
     _Worksheet worksheet = (Worksheet) workbook.Sheets["Sayfa1"];
     worksheet.Name = "Export";
     for (var i = 1; i < dataGridView1.Columns.Count + 1; i++)
            worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
     for (var i = 0; i < dataGridView1.Rows.Count - 1; i++)
     for (var j = 0; j < dataGridView1.Columns.Count; j++)
            worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value;
    
     var sfd = new SaveFileDialog();
     sfd.Filter = "Excel Document(*.xlsx)|*.xlsx";
     sfd.FileName = "Export";
     if (sfd.ShowDialog() == DialogResult.OK)
            workbook.SaveAs(sfd.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
     app.Quit();
