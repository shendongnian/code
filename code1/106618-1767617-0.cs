    using System;
    using Excel = Microsoft.Office.Interop.Excel;
    
    public class MyClass
    {
    	public void FormatRange(Excel.Worksheet sheet)
    	{
    		Excel.Range range = sheet.Cells["1","A"];
    		range.Interior.ColorIndex = 15;//This sets it to gray
    		range.Font.Bold = true;//Sets the Bold
    		range.NumberFormat = "@";//Sets it to numeric
    	}
    }
