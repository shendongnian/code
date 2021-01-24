    void Main()
    {
    	Microsoft.Office.Interop.Excel.Application xl = new Microsoft.Office.Interop.Excel.Application();
    	var workbook = xl.Workbooks.Add();
    	xl.Visible = true;
    
    	Worksheet sht = ((Worksheet)workbook.ActiveSheet);
    	Range target = (Range)sht.Range["A1"];
    
    	string strCon = @"ODBC;Driver={SQL Server Native Client 11.0};Server=.\SQLExpress;Database=Test;Trusted_Connection=yes";
    	string strSQL = "select * from MyTable";
    	var qt = sht.QueryTables.Add(strCon, target, strSQL);
    	qt.Refresh();
    }
