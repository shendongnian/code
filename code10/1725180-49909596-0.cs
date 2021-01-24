		var headers = new List<string>();
		ds = reader.AsDataSet(new ExcelDataSetConfiguration()
		{
			ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
			{
				UseHeaderRow = true,
				ReadHeaderRow = rowReader => {
					for (var i = 0; i < rowReader.FieldCount; i++)
						headers.Add(Convert.ToString(rowReader.GetValue(i)));
				},
				FilterColumn = (columnReader, columnIndex) =>
					headers.IndexOf("string") != columnIndex
			}
		});
