    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Office.Interop.Excel;
    
    namespace ExcelTest1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook wbv = excel.Workbooks.Open("H:\\my_documents\\town\\personnel\\May 18 MuniRosterDetailReport.xlsx");
                Microsoft.Office.Interop.Excel.Worksheet wx = excel.ActiveSheet as Microsoft.Office.Interop.Excel.Worksheet;
                Range dataRange = null;
                int totalColumns = wx.UsedRange.Columns.Count;
                int totalRows = wx.UsedRange.Rows.Count;
    				List<string> m_column_headings = new List<string>();
    				dataRange = (Range)wx.UsedRange;
    
    				int row = 1;
    				for(int colIdx = 1; colIdx < (totalColumns + 1); colIdx++)
    				{
    					Range tempRange = (Range )wx.Cells[row, colIdx];
    					m_column_headings.Add(String.Format(tempRange.Value2.ToString() + ","));
    				}
    				
                
    				int i = 0;
                wbv.Close(true, Type.Missing, Type.Missing);
                excel.Quit();
            }
        }
    }
