    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using Microsoft.Office.Interop.Excel;
    using System.Runtime.InteropServices;
    using System.Threading; 
    using System.Globalization;
     
     
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
     
            public void ExportDTToExcel()
            {
     
                Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                app.Visible = true;
     
                string culture = System.Threading.Thread.CurrentThread.CurrentCulture.ToString();//"en-GB";
                CultureInfo ci = new CultureInfo(culture);
     
                bool systemseparators = app.UseSystemSeparators  ;
                if (app.UseSystemSeparators == false)
                {
     
                    app.UseSystemSeparators = true;
     
                }
     
                // Content.   
                Workbook wb = app.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                Worksheet ws = (Worksheet)wb.ActiveSheet;            
                try
                {
                    SetCellValue("3706888.0300", ws, 0, 0, ci);
                    SetCellValue("2587033.8000", ws, 1, 0, ci);
                    SetCellValue("2081071.1800", ws, 2, 0, ci);
                    SetCellValue("9030160.3333", ws, 3, 0, ci);
                    SetCellValue("42470.9842", ws, 4, 0, ci);
                    SetCellValue("4465546.2800", ws, 5, 0, ci);
                    SetCellValue("1436037.3200", ws, 6, 0, ci);
                    SetCellValue("111650.0000", ws, 7, 0, ci);
                    SetCellValue("2567007.0833", ws, 8, 0, ci);
     
                }
                catch (Exception e)
                {
     
     
                        MessageBox.Show(e.Message);
     
                }
     
                app.UseSystemSeparators = systemseparators;
                Marshal.ReleaseComObject(app);
                Marshal.ReleaseComObject(wb);
                Marshal.ReleaseComObject(ws);
                app = null;
                wb = null;
                ws = null;
            }
     
            private static void SetCellValue(string data, Worksheet ws,int row, int col, CultureInfo ci)
            {
                    double val;
                    try
                    {
                        val = Convert.ToDouble(data);
                        Console.WriteLine(val);
                    }
                    catch (Exception e)
                    {
     
                        //Util.Log("Null Value ignored.", LogType.ERROR);
                        return;
                    }
     
                    try
                    {
                        string s = val.ToString();
                        ws.Cells[row + 2 , col + 1] = s;
     
                        //Util.Log("S:" + s, LogType.ERROR);
                    }
                    catch
                    {
                        //Util.Log("Null Value ignored.", LogType.ERROR);
                    }
                }
     
            private void button1_Click(object sender, EventArgs e)
            {
                this.Cursor = Cursors.WaitCursor;
                ExportDTToExcel();
                this.Cursor = Cursors.Default;
            }
    
     
        }
    }
 
 
