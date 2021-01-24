    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    using System.Data.SqlClient;
    using Excel = Microsoft.Office.Interop.Excel; 
    
    namespace Import_CSV_file_into_DataGridView
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void btnBrowse_Click(object sender, EventArgs e)
            {
                OpenFileDialog dlg = new OpenFileDialog();
                DialogResult dlgResult = dlg.ShowDialog();
                if (dlgResult == DialogResult.OK)
                {
                    txtPath.Text = dlg.FileName;
                }
            }
    
            private void btnLoadData_Click(object sender, EventArgs e)
            {
                string rowValue;
                string[] cellValue;
                
                if (System.IO.File.Exists(txtPath.Text))
                {
                    System.IO.StreamReader streamReader = new StreamReader(txtPath.Text);
    
                    // Reading header
                    rowValue = streamReader.ReadLine();
                    cellValue = rowValue.Split(',');                
                    for (int i = 0; i <= cellValue.Count() - 1; i++)
                    {
                        DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                        column.Name = cellValue[i];
                        column.HeaderText = cellValue[i];
                        dataGridView1.Columns.Add(column);
                    }
    
                    // Reading content
                    while (streamReader.Peek() != -1)
                    {
                        rowValue = streamReader.ReadLine();
                        cellValue = rowValue.Split(',');
                        dataGridView1.Rows.Add(cellValue);
                    }
    
                    streamReader.Close();
                }
                else
                {
                    MessageBox.Show("No File is Selected");
                }
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                Excel.Application xlApp ;
                Excel.Workbook xlWorkBook ;
                Excel.Worksheet xlWorkSheet ;
                object misValue = System.Reflection.Missing.Value;
    
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                int i = 0;
                int j = 0; 
    
                for (i = 0; i <= dataGridView1.RowCount  - 1; i++)
                {
                    for (j = 0; j <= dataGridView1.ColumnCount  - 1; j++)
                    {
                        DataGridViewCell cell = dataGridView1[j, i];
                        xlWorkSheet.Cells[i + 1, j + 1] = cell.Value;
                    }
                }
    
                xlWorkBook.SaveAs("C:\\Users\\Excel\\Desktop\\test.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();
    
                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
    
                MessageBox.Show("Excel file created , you can find the file C:\\Users\\Excel\\Desktop\\test.xls");
            }
    
            private void releaseObject(object obj)
            {
                try
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                    obj = null;
                }
                catch (Exception ex)
                {
                    obj = null;
                    MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
                }
                finally
                {
                    GC.Collect();
                }
            }
            }
    }
