    public int DataWriter<THeader, TModel>(ExcelWorksheet worksheet, IList<THeader> headerColumns, IList<TModel> modelData, int rowIndex) 
    	where THeader: IHeader 
    	where TModel: IModel 
    {
    	var dataHeaderCount = headerColumns.Count();
    	var totalItems = modelData.Count;
    	var lineIndex = rowIndex;
    	for (var i = 0; i < totalItems; i++) 
    	{
    		var colIndex = 1;
    		foreach (var dataHeader in headerColumns) {
    			worksheet.DataWriter(dataHeader, rowIndex, colIndex, colIndex);
    			using (var cell = worksheet.Cells[rowIndex, colIndex++]) {
    				var valueToWrite = GetColumnValue(dataHeader.Field, modelData[i]);
    				cell.Value = valueToWrite;
    
    				worksheet.Column(colIndex - 1).AutoFit();
    
    				if (modelData[i].IsCatRow) {
    					worksheet.SetBackGroundColor(ExcelFillStyle.Solid, Color.LightGray, rowIndex,
    						dataHeaderCount, 1);
    				}
    
    			}
    		}
    		rowIndex++;
    	}
    	if (modelData[0].CategoryTitle == ReportConstants.Total) {
    		worksheet.SetBottomBorder(ExcelBorderStyle.Thin, Color.Black, lineIndex, dataHeaderCount, 1);
    	}
    	return rowIndex;
    }
