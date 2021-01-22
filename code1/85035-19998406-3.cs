    public DataTable ReadPasswordProtectedExcel(string ExcelFilePath, string Password)
    {
    	String TempExcelFilePath = string.Empty;            
    	DataTable _DataTable = new DataTable();
    
    	#region Get ExcelFile and Remove Password
    	{
    		String TempExcelFileName = string.Empty;
    		String DirectoryPath = string.Empty;
    		Microsoft.Office.Interop.Excel.Application excelapp = new Microsoft.Office.Interop.Excel.Application();
    		excelapp.Visible = false;
    
    		Microsoft.Office.Interop.Excel.Workbook newWorkbook = excelapp.Workbooks.Open(ExcelFilePath, 0,
    											true, 5, Password, "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true,
    											false, 0, true, false, false);
    
    		TempExcelFileName = string.Format("{0}_{1}", "__", Path.GetFileName(ExcelFilePath)); // __xxx.xlsx
    		TempExcelFilePath = String.Format("{0}/{1}", Path.GetDirectoryName(ExcelFilePath), TempExcelFileName);
    
    		/// Create new excel file and remove password.
    		newWorkbook.SaveAs(TempExcelFilePath, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, "", "",
    		false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
    		Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
    
    		newWorkbook.Close(true, "", false);
    
    		excelapp.Quit();
    		Marshal.ReleaseComObject(excelapp);
    	}
    	#endregion
    
    	#region Get data from excel file by using OLEDB
    	{
    		_DataTable = ReadExcelFileInOLEDB(TempExcelFilePath);
    		///Delete excel file
    		File.Delete(TempExcelFilePath);
    	}
    	#endregion
    
    	return _DataTable;
    }
    
    public DataTable ReadExcelFileInOLEDB(string _ExcelFilePath)
    {
    	string ConnectionString = string.Empty;
    	string SheetName = string.Empty;           
    	DataTable _DataTable = null;
    	DataSet _DataSet = null;
    
    	try
    	{
    		ConnectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0;HDR=YES;IMEX=0;'", _ExcelFilePath);
    		using (OleDbConnection _OleDbConnection = new OleDbConnection(ConnectionString))
    		{
    			_OleDbConnection.Open();
    			_DataTable = _OleDbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
    
    			if (_DataTable == null)
    				return null;
    
    			SheetName = _DataTable.Rows[0]["TABLE_NAME"].ToString();
    			ConnectionString = string.Format("SELECT * FROM [{0}]", SheetName);
    
    			using (OleDbCommand _OleDbCommand = new OleDbCommand(ConnectionString, _OleDbConnection))
    			{
    				using (OleDbDataAdapter _OleDbDataAdapter = new OleDbDataAdapter())
    				{
    					_OleDbDataAdapter.SelectCommand = _OleDbCommand;
    
    					_DataSet = new DataSet();
    					_OleDbDataAdapter.Fill(_DataSet, "PrintInfo");
    					return _DataSet.Tables["PrintInfo"];
    				}
    			}
    		}
    	}
    	catch (Exception ex)
    	{
    		throw ex;
    	}
    }
