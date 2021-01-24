    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Data.OleDb;
    using Excel = Microsoft.Office.Interop.Excel;
    using System.Data.SqlClient;
    
    
    namespace WindowsFormsApplication6
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                DataTable table = new DataTable();
                string strConn = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1;TypeGuessRows=0;ImportMixedTypes=Text\"", "C:\\Users\\Ryan\\Desktop\\Coding\\DOT.NET\\Samples C#\\Export DataGridView to Excel File & Export to Text File\\Import_List.xls");
                using (OleDbConnection dbConnection = new OleDbConnection(strConn))
                {
                    using (OleDbDataAdapter dbAdapter = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", dbConnection)) //rename sheet if required!
                        dbAdapter.Fill(table);
                        dataGridView1.DataSource = table;
                    int rows = table.Rows.Count;
    
                    this.dataGridView1.DefaultCellStyle.ForeColor = Color.Blue;
                    this.dataGridView1.DefaultCellStyle.BackColor = Color.Beige;
                }
            }
    
             private void button2_Click(object sender, EventArgs e)
                {
    
                    // creating Excel Application
                    Microsoft.Office.Interop.Excel._Application app  = new Microsoft.Office.Interop.Excel.Application();
                    // creating new WorkBook within Excel application
                    Microsoft.Office.Interop.Excel._Workbook workbook =  app.Workbooks.Add(Type.Missing);
                    // creating new Excelsheet in workbook
                    Microsoft.Office.Interop.Excel._Worksheet worksheet = null;                   
    
                    // see the excel sheet behind the program
                    app.Visible = true;
    
    
                   // get the reference of first sheet. By default its name is Sheet1.
                   // store its reference to worksheet
                   worksheet = workbook.Sheets["Sheet1"];
                   worksheet = workbook.ActiveSheet;
    
                   // changing the name of active sheet
                   worksheet.Name = "Exported from gridview";
    
    
                   // storing header part in Excel
                   for(int i=1;i<dataGridView1.Columns.Count+1;i++)
                    {
                        worksheet.Cells[1, i] = dataGridView1.Columns[i-1].HeaderText;
                    }
    
    
                    // storing Each row and column value to excel sheet
                    for (int i=0; i < dataGridView1.Rows.Count-1 ; i++)
                    {
                        for(int j=0;j<dataGridView1.Columns.Count;j++)
                        {
                            worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                        }
                    }
    
    
                    // save the application
                    workbook.SaveAs("c:\\output.xls",Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive , Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    // Exit from the application
    
                  app.Quit();
                }
    
             private void button3_Click(object sender, EventArgs e)
             {
    
                SqlConnection cnn ;
                string connectionString = null;
                string sql = null;
                connectionString = "data source=Excel-PC\\SQLEXPRESS;initial catalog=Northwind;Trusted_Connection=True;";
                cnn = new SqlConnection(connectionString);
                cnn.Open();
                sql = "SELECT * FROM Products";
                SqlDataAdapter dscmd = new SqlDataAdapter(sql, cnn);
                DataSet ds = new DataSet();
                dscmd.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
    
    
    
            private void button4_Click(object sender, EventArgs e)
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
    
                xlWorkBook.SaveAs("c:\\test.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();
                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
                MessageBox.Show("Excel file created , you can find the file c:\\test.xls");
            }
    
            //Note this part of code gets data from DataGridView and fills cells.
            // storing Each row and column value to excel sheet
            //for (int i=0; i < dataGridView1.Rows.Count-1 ; i++)
            //{
            //    for(int j=0;j<dataGridView1.Columns.Count;j++)
            //    {
            //        worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
            //    }
            //}
    
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
    
            private void button7_Click(object sender, EventArgs e)
            {
                //This line of code creates a text file for the data export.
                System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\\Users\\Excel\\Desktop\\Excel_Files\\Book1.txt");
                try
                {
                    string sLine = "";
    
                    //This for loop loops through each row in the table
                    for (int r = 0; r <= dataGridView1.Rows.Count - 1; r++)
                    {
                        //This for loop loops through each column, and the row number
                        //is passed from the for loop above.
                        for (int c = 0; c <= dataGridView1.Columns.Count - 1; c++)
                        {
                            sLine = sLine + dataGridView1.Rows[r].Cells[c].Value;
                            if (c != dataGridView1.Columns.Count - 1)
                            {
                                //A comma is added as a text delimiter in order
                                //to separate each field in the text file.
                                //You can choose another character as a delimiter.
                                sLine = sLine + ",";
                            }
                        }
                        //The exported text is written to the text file, one line at a time.
                        file.WriteLine(sLine);
                        sLine = "";
                    }
    
                    file.Close();
                    System.Windows.Forms.MessageBox.Show("Export Complete.", "Program Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (System.Exception err)
                {
                    System.Windows.Forms.MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    file.Close();
                }
            }
    
            private void button5_Click(object sender, EventArgs e)
            {
                const int WORKSHEETSTARTROW = 1;
                const int WORKSHEETSTARTCOL = 1;
    
                var excelApp = new Excel.Application();
                excelApp.Visible = true;
                Excel.Workbook excelbk = excelApp.Workbooks.Add(Type.Missing);
                Excel.Worksheet xlWorkSheet1 = (Excel.Worksheet)excelbk.Worksheets["Sheet1"];
                int worksheetRow = WORKSHEETSTARTROW;
                for (int rowCount = 0; rowCount < dataGridView1.Rows.Count - 1; rowCount++)
                {
                    int worksheetcol = WORKSHEETSTARTCOL;
                for (int colCount = 0; colCount < dataGridView1.Columns.Count - 1; colCount++)
                {
                    Excel.Range xlRange = (Excel.Range)xlWorkSheet1.Cells[WORKSHEETSTARTROW, worksheetcol];
                    xlRange.Value2 = dataGridView1.Columns[colCount].Name;
                    worksheetcol += 1;
                
    
                        if (dataGridView1.Rows[rowCount].Cells[colCount].Style.Font != null)
                        {
                            xlRange.Font.Bold = dataGridView1.Rows[rowCount].Cells[colCount].Style.Font.Bold;
                            xlRange.Font.Italic = dataGridView1.Rows[rowCount].Cells[colCount].Style.Font.Italic;
                            xlRange.Font.Underline = dataGridView1.Rows[rowCount].Cells[colCount].Style.Font.Underline;
                            xlRange.Font.FontStyle = dataGridView1.Rows[rowCount].Cells[colCount].Style.Font.FontFamily;
                        }
                        worksheetcol += 1;
                    }
                    worksheetRow += 1;
    
                }
            }
        }
    }
