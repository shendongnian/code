	public static void ExcelExport(DataTable data, String fileName)
	{   
		try
		{
			using (ExcelWriter_StackOverFlow writer = new ExcelWriter_StackOverFlow(fileName))
			{
				writer.WriteStartDocument();
				// Write the worksheet contents
				writer.WriteStartWorksheet("Sheet1");
				//Write header row
				writer.WriteStartRow();
				foreach (DataColumn col in data.Columns)
					writer.WriteExcelUnstyledCell(col.Caption);
				writer.WriteEndRow();
				//write data
				foreach (DataRow row in data.Rows)
				{
					writer.WriteStartRow();
					foreach (object o in row.ItemArray)
					{
						if (o.ToString().Length <= 0)
						{
							writer.WriteExcelAutoStyledCell(string.Empty);
						}
						else {
							Type _Type = o.GetType();
							if (_Type.Equals(typeof(System.Guid)))
							{
								string GuidValueStr = Convert.ToString(o);                                    
								writer.WriteExcelAutoStyledCell((object)GuidValueStr);
								continue;
							}
							writer.WriteExcelAutoStyledCell(o);
						}
					}
					writer.WriteEndRow();
				}
				// Close up the document
				writer.WriteEndWorksheet();
				writer.WriteEndDocument();
				writer.Close();
					
			}
		}
		catch (Exception myException)
		{
			throw myException;
		}            
	}
