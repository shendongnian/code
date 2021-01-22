    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using wf = System.Windows.Forms;
    using xl = Microsoft.Office.Interop.Excel;
        
    public static class ExcelTest
    {	
    	public xl.Application xlApp = null;
    	public xl.Workbook xlWb = null;
    	public xl.Worksheet xlWs = null;
    	
    	public static bool IsXlFileOpen(string xlFileName)
    	{		
    		try
    		{		
    			if (!File.Exists(xlFileName))
    			{
    				wf.MessageBox.Show("Excel File does not exists!");
    				return false;
    			}
    
    			try
    			{
    				xlApp = (xl.Application)Marshal.GetActiveObject("Excel.Application");
    			}
    			catch (Exception ex)
    			{
    				return false;
    			}
    
    			foreach (xl.Workbook wb in xlApp.Workbooks)
    			{
    				if (wb.FullName == xlFileName)
    				{
    					xlWb = wb;
    					return true;
    				}
    			}
    
    			return false;
    		}
    		catch (Exception ex)
    		{
    			return false;
    		}
    	}
    
    	public static void GetXlSheet(string xlFileName,
    									string xlSheetName)
    	{
    		try
    		{
    			if (!File.Exists(xlFileName))
    			{
    				wf.MessageBox.Show("Excel File does not exists!");
    				return false;
    			}
    
    			xlApp = (xl.Application)Marshal.GetActiveObject("Excel.Application");
    			foreach (xl.Workbook wb in xlApp.Workbooks)
    			{
    				if (wb.FullName == xlFileName)
    				{
    					if (!xlWb
                            .Sheets
                            .Cast<xl.Worksheet>()
                            .Select(s => s.Name)
                            .Contains(xlSheetName))
    					{
    						wf.MessageBox.Show("Sheet name does not exist in the Excel workbook!");
    						return;
    					}
    					xlWs = xlWb.Sheets[xlSheetName];
    				}
    			}
    		}
    		catch (Exception ex)
    		{
    			// catch errors
    		}
    	}	
    }
