       Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
       Microsoft.Office.Interop.Excel.Sheets xlBigSheet;
       object misValue;
       String myPath;
       private void Button1_Click(object sender, EventArgs e)
       {
           string myPath = @"C:\\Users\\N0m4d\\Desktop\\Longhouse\\database.xlsx"; // this must be full path.
           FileInfo fi = new FileInfo(myPath);
           if (!fi.Exists)
           {
               Console.Out.WriteLine("file doesn't exist!");
           }
           else
           {
               var excelApp = new Microsoft.Office.Interop.Excel.Application();
               var workbook = excelApp.Workbooks.Open(myPath);
               Worksheet worksheet = workbook.ActiveSheet as Worksheet;
          Microsoft.Office.Interop.Excel.Range lastRow = worksheet.Cells.SpecialCells(Microsoft.Office.Interop.Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
               int lastUsedRow = last.Row;
               int newRow = lastUsedRow + 1;
               Range range1 = worksheet.Cells[newRow , 1] as Range;
               range1.Value2 = textBox1.Text;
               Range range2 = worksheet.Cells[newRow , 2] as Range;
               range2.Value2 = textBox2.Text;
               Range range3 = worksheet.Cells[newRow , 3] as Range;
               range3.Value2 = textBox3.Text;
               Range range4 = worksheet.Cells[newRow , 4] as Range;
               range4.Value2 = textBox4.Text;
               Range range5 = worksheet.Cells[newRow , 5] as Range;
               range5.Value2 = textBox5.Text;
               Range range6 = worksheet.Cells[newRow , 6] as Range;
               range6.Value2 = textBox6.Text;
               excelApp.Visible = true;
               workbook.Save();
               //workbook.Close();
               textBox1.Text = string.Empty;
               textBox2.Text = string.Empty;
               textBox3.Text = string.Empty;
               textBox4.Text = string.Empty;
               textBox5.Text = string.Empty;
               textBox6.Text = string.Empty;
           }
       }
     
