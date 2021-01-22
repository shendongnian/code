    DataSet result;
    const string path = @"....\Test.xlsx";
    using ( var fileStream = new FileStream( path, FileMode.Open, FileAccess.Read ) )
    {
    	using ( var excelReader = ExcelReaderFactory.CreateOpenXmlReader( fileStream ) )
    	{
    		excelReader.IsFirstRowAsColumnNames = true;
    		result = excelReader.AsDataSet();
    	}
    }
