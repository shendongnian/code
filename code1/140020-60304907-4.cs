    using Microsoft.Office.Interop.Excel;
    using _Excel = Microsoft.Office.Interop.Excel;
	public class Excel 
    {
        string path = "";
        Application excel = new _Excel.Application();
        Workbook wb;
        Worksheet ws;
        public Range xlRange;
        static bool saveChanges = false;
        static int excelRow = 0;
        static List<string> columnHeaders = new List<string>();    
		public Excel(string path, int Sheet = 1)
        {
            this.path = path;
            wb = excel.Workbooks.Open(path);
            ws = wb.Worksheets[Sheet];
            xlRange = ws.UsedRange;
            excelRow = 0;
            columnHeaders = new List<string>();
        }
        public void SaveFile(bool save = true)
        {
            saveChanges = save;
        }
        public void Close()
        {
            wb.Close(saveChanges);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(wb);
            excel.Quit();
        }                      
        public void XMLToExcel(string xmlFilePath)
		{
			var dt = XMLFunctions.CreateDataTableFromXmlFile(xmlFilePath);
			AddDataTableToExcel(dt);
		}
        public void AddDataTableToExcel(System.Data.DataTable table)
		{       
			// Creating Header Column In Excel
            for (int i = 0; i < table.Columns.Count; i++)   
            {
                if (!columnHeaders.Contains(table.Columns[i].ColumnName))
                {
                    ws.Cells[1, columnHeaders.Count() + 1] = table.Columns[i].ColumnName;
                    columnHeaders.Add(table.Columns[i].ColumnName);
                }
            } 
            // Get the rows
			for (int k = 0; k < table.Columns.Count; k++)
			{
				var columnNumber = columnHeaders.FindIndex(x => x.Equals(table.Columns[k].ColumnName));
				ws.Cells[excelRow + 2, columnNumber + 1] = table.Rows[0].ItemArray[k].ToString();
			}
			excelRow++; 
			SaveFile(true);         
		}
    }
