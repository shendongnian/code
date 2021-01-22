    using System;
    using System.Collections.Generic;
    using System.Reflection;
    
    using Microsoft.Office.Interop.Excel;
    
    namespace Project1
    {
      public class ExportExcel
      {
        public void Export(string fileName, List<List<string>> data)
    	{
    	  _Application excel = null;
    	  _Workbook wb = null;
    	  try
    	  {
    	    excel = new ApplicationClass { Visible = false }; // new excel application (not visible)
    	    wb = excel.Workbooks.Add(Missing.Value); // new excel file
    
    	    var sh = ((_Worksheet)wb.ActiveSheet); // current sheet
    	    for (var i = 0; i < data.Count; i++)
    	    {
    	      var listMaster = data[i];
    	      for (var j = 0; j < listMaster.Count; j++)
    	      {
    	        sh.get_Range(sh.Cells[j + 1, i + 1], sh.Cells[j + 1, i + 1]).Value2 = listMaster[j];
                // get_Range(start, end) where start, end is in R1C1 notation
    	      }
            }
          }
    	  finally
    	  {
    	    if (wb != null)
    	    {
    	      wb.SaveAs(fileName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            }
    	    if (excel != null)
    	    {
    	      excel.Quit();
    	    }
    	    GC.Collect();
    	  }
    	}
      }
    }
