    using ( MSExcel.Application app = MSExcel.Application.CreateApplication() ) {
    	MSExcel.Workbook book1 = app.Workbooks.Open( this.txtOpen_FilePath.Text );
    	MSExcel.Worksheet sheet1 = (MSExcel.Worksheet)book1.Worksheets[1];
    	MSExcel.Range range = sheet1.GetRange( "A1", "F13" );
     
    	object value = range.Value; //the value is boxed two-dimensional array
    }
