private Microsoft.Office.Interop.Excel.Application ObjExcel;
        private Microsoft.Office.Interop.Excel.Workbook ObjWorkBook;
        private Microsoft.Office.Interop.Excel.Worksheet ObjWorkSheet;
 
string fileName = System.Windows.Forms.Application.StartupPath + "\\" + textBox1.Text + ".xlsx";
            MessageBox.Show(fileName);
            try
            {
                ObjExcel = new Microsoft.Office.Interop.Excel.Application();
                
                ObjWorkBook = ObjExcel.Workbooks.Add(System.Reflection.Missing.Value);
                
                ObjWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ObjWorkBook.Sheets[1];
 
                
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewRow row = dataGridView1.Rows[i]; 
                    for (int j = 0; j < row.Cells.Count; j++) 
                    {ObjExcel.Cells[1, 1]="id";
                ObjExcel.Cells[1, 1]="column";
                ObjExcel.Cells[1, 2]="column";
                ObjExcel.Cells[1, 3]="column";
                        ObjExcel.Cells[i + 1, j + 1] = row.Cells[j].Value;
                    }
                }
                ObjWorkBook.Save();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error"); }
 
            ObjWorkBook.Close(null, System.Windows.Forms.Application.StartupPath + "\\" + textBox1.Text + ".xlsx", null);
                    
                    ObjExcel.Quit();
                    ObjWorkBook = null;
                    ObjWorkSheet = null;
                    ObjExcel = null;
                    GC.Collect();
            
            this.Text = this.Text + " - " + textBox1.Text + ".xlsx";
