	using DocumentFormat.OpenXml.Packaging;
	using DocumentFormat.OpenXml.Spreadsheet;
	~~~~~~
	~~~~~~
	~~~~~~
	private DataTable GetExcelTablesFromWorksheets(string FullFileName)
	{
		DataTable excelTablesDT = new DataTable();
		excelTablesDT.Columns.Add("Spreadsheet");
		excelTablesDT.Columns.Add("TableName");
		excelTablesDT.Columns.Add("CellRange");
		excelTablesDT.Columns.Add("HasHeader", typeof(bool));
		using (SpreadsheetDocument sd = SpreadsheetDocument.Open(FullFileName, false))
		{
			if(sd != null && sd.WorkbookPart != null)
			{
				IEnumerable<Sheet> sheets = sd.WorkbookPart.Workbook.Sheets.Elements<Sheet>();
				IEnumerable<WorksheetPart> wsps = sd.WorkbookPart.WorksheetParts;
				if (wsps != null)
				{
					foreach (WorksheetPart wsp in wsps)
					{
						if (wsp != null)
						{
							IEnumerable<TableDefinitionPart> tdps = wsp.TableDefinitionParts;
							if (tdps != null)
							{
								foreach (TableDefinitionPart tdp in tdps)
								{
									if (tdp != null)
									{
										Table t = tdp.Table;
										if (t != null)
										{
											string Spreadsheet = "";
											string SpreadsheetId = sd.WorkbookPart.GetIdOfPart(wsp);
											Sheet currentSheet = sheets.FirstOrDefault(s => s.Id.HasValue && s.Id.Value.Equals(SpreadsheetId, StringComparison.OrdinalIgnoreCase));
											if(currentSheet != null)
											{
												Spreadsheet = currentSheet.Name;
											}
											string TableName = t.DisplayName;
											string CellRange = t.Reference.HasValue ? t.Reference.Value : "";
											bool hasHeader = !(t.HeaderRowCount != null && t.HeaderRowCount.HasValue && t.HeaderRowCount.Value == 0);
											//Add to DataTable
											excelTablesDT.Rows.Add(new object[] { Spreadsheet, TableName, CellRange, hasHeader });
										}
									}
								}
							}
						}
					}
				}
			}
		}
		return excelTablesDT;
	}
