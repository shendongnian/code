    char csvDelimiter = ';';
    using(var pck = new ExcelPackage())
    {
    	ExcelWorksheet ws = null;
    	if(path.EndsWith(".csv"))
    	{
    		ws = pck.Workbook.Worksheets.Add("Sheet1");
    		ExcelTextFormat format = new ExcelTextFormat()
    		{
    			Delimiter = csvDelimiter 
    		};
    		ws.Cells[1, 1].LoadFromText(File.ReadAllText(path), format);
    	}
    	else
    	{
    		using (var stream = File.OpenRead(path))
            {
                pck.Load(stream);
            }
            ws = pck.Workbook.Worksheets.First();
    	}
        //The rest of your code
    
    }
