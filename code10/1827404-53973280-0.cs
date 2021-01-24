    for (i = 0; i < data.Rows.Count; ++i)
    {
        IRow row = sheet.CreateRow(count);
        for (j = 0; j < data.Columns.Count; ++j)
        {
    	if (Double.TryParse(data.Rows[i][j].ToString(), out d))
    	{
    	    row.CreateCell(j).SetCellValue(d);
    	}
    	else
    	{
    	   ICell cell = row.CreateCell(j);
    	    cell.SetCellType(CellType.Formula);
    	    cell.SetCellFormula(data.Rows[i][j].ToString().Replace("=", string.Empty));
    	}
    
        }
        ++count;
    }
    
    if (workbook is XSSFWorkbook)
    {
        XSSFFormulaEvaluator.EvaluateAllFormulaCells(workbook);
    }
    else
    {
        HSSFFormulaEvaluator.EvaluateAllFormulaCells(workbook);
    }
    workbook.Write(fs);
