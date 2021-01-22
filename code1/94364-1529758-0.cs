    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;
    using Excel = Microsoft.Office.Interop.Excel;
    using System.Reflection;
    using System.Threading;
    using System.Diagnostics;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Xml;
    using System.Data.SqlClient;
    
    namespace ExcelDemo
    {
        static class ExcelImportExport
        {
            public static void ExportToExcel(string strFileName, string strSheetName)
            {
                // Run the garbage collector
                GC.Collect();
    
                // Delete the file if it already exists
                if (System.IO.File.Exists(strFileName))
                {
                    System.IO.File.SetAttributes(strFileName, FileAttributes.Normal);
                    System.IO.File.Delete(strFileName);
                }
    
                // Open an instance of excel. Create a new workbook.
                // A workbook by default has three sheets, so if you just want a single one, delete sheet 2 and 3
                Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                Excel._Workbook xlWB = (Excel._Workbook)xlApp.Workbooks.Add(Missing.Value);
                Excel._Worksheet xlSheet = (Excel._Worksheet)xlWB.Sheets[1];
                ((Excel._Worksheet)xlWB.Sheets[2]).Delete();
                ((Excel._Worksheet)xlWB.Sheets[2]).Delete();
                
                xlSheet.Name = strSheetName;
                // Write a value into A1
                xlSheet.Cells[1, 1] = "Some value";
    
                // Tell Excel to save your spreadsheet
                xlWB.SaveAs(strFileName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                xlApp.Quit();
    
                // Release the COM object, set the Excel variables to Null, and tell the Garbage Collector to do its thing
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlSheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWB);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
    
                xlSheet = null;
                xlWB = null;
                xlApp = null;
    
                GC.Collect();
    
            }
            
    
        }
    
    }
