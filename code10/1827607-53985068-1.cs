	private async Task ProcessFile(string series_id)
	{
		string json = await GetAsync();
	
		SeriesObject obj = JsonConvert.DeserializeObject<SeriesObject>(json);
	
		DataTable dataTableConversion = ConvertToDataTable(obj.observations);
		dataTableConversion.TableName = series_id;
	
		using (SqlConnection dbConnection = new SqlConnection("SQL Connection"))
		{
			dbConnection.Open();
			using (SqlBulkCopy s = new SqlBulkCopy(dbConnection))
			{
				s.DestinationTableName = dataTableConversion.TableName;
				foreach (var column in dataTableConversion.Columns)
					s.ColumnMappings.Add(column.ToString(), column.ToString());
				await s.WriteToServerAsync(dataTableConversion);
			}
	
			Console.WriteLine("File: {0} Complete", series_id);
		}
	}
	
	private async Task SQLBulkLoader()
	{
		var tasks = indicators.file_list.Select(f => ProcessFile(f.series_id));
		await Task.WhenAll(tasks);
	}
 
