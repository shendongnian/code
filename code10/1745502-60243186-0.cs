	public class TrimmedTableSample 
	{
		#region Properties
		int HeaderRowIndex { get; set; }
		#endregion
		
		#region Methods
		public void Read(string documentPath)
		{
			using (var stream = File.Open(documentPath, FileMode.Open, FileAccess.Read))
			using (var reader = ExcelReaderFactory.CreateReader(stream))
			{
				var dataSet = reader.AsDataSet(new ExcelDataSetConfiguration()
				{
					UseColumnDataType = true,
					ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
					{
						EmptyColumnNamePrefix = "Column ",
						UseHeaderRow = true,
						ReadHeaderRow = (reader) =>
						{
							bool empty = true;
							HeaderRowIndex = 0;
							while (empty)
							{
								for (var i = 0; i < reader.FieldCount && empty; i++)
									empty = string.IsNullOrWhiteSpace(reader.GetString(i));
												
								if (empty)
								{
									empty = reader.Read(); // Only continue if more content is available
									HeaderRowIndex++; // Keep track of the first row position.
								}
							}
						},
						FilterColumn = (reader, index) =>
						{
							bool empty = false;
							// Start reading the table from the beginning
							reader.Reset();
							// Head to the first row with content
							int rowIndex = 0;
							while (rowIndex < HeaderRowIndex)
							{
								reader.Read();
								rowIndex++;
							}
							while (reader.Read())
							{
								// Decide if the current column is empty
								if (reader[index] == null || string.IsNullOrEmpty(reader[index].ToString()))
									continue;
								empty = true;
								break;
							}
							// Start over again (This allows the reader to automatically read the rest of the content itself)
							reader.Reset();
							reader.Read();
							// Head over to the first row with content
							rowIndex = 0;
							while (rowIndex < HeaderRowIndex)
							{
								reader.Read();
								rowIndex++;
							}
							
							// Return info on whether this column should be ignored or not.
							return empty;
						}
					}
				});  
			}
		}
		#endregion
	}
