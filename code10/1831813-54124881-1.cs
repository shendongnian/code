    using OfficeOpenXml;
    using System.Data;
    using System.IO;
    void SaveTableAsExcelSheet(DataTable dt, string filePath)
    {
    	var fi = new FileInfo(filePath);
    	using (ExcelPackage pck = new ExcelPackage(fi))
    	{
    		ExcelWorksheet ws = pck.Workbook.Worksheets.Add(dt.TableName);
    		ws.Cells["A1"].LoadFromDataTable(dt, true);
    		pck.Save();
    	}
    }
