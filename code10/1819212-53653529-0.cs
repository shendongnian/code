	void DoSomething(ReportDataDataContract dataContranct)
	{
		if (dataContranct != null)
		{
			if (dataContranct.DecimalValue != null)
			{
			
				Columns.Add(m => dataContranct.DecimalValue).Titled(dataContranct.Name).Encoded(false).
					Sanitized(false).RenderValueAs(
						m => (string.IsNullOrEmpty(@dataContranct.DisplayFormat)) ? 
							Convert.ToDecimal(@dataContranct.DecimalValue).ToString("N") : 
							Convert.ToDecimal(@dataContranct.DecimalValue).ToString(@dataContranct.DisplayFormat));
				if (dataContranct.SumValue || dataContranct.AvgValue)
				{
					displaySummary = true;
					SummaryData.Add(
						new ReportDataDataContract
							{
								Name = dataContranct.Name,
								AvgValue = dataContranct.AvgValue,
								DecimalValue = 0
							});
				}
			}
			else if (dataContranct.IntValue != null)
			{
				Columns.Add(m => dataContranct.IntValue).Titled(dataContranct.Name);
				if (dataContranct.SumValue || dataContranct.AvgValue)
				{
					displaySummary = true;
					SummaryData.Add(
						new ReportDataDataContract
							{
								Name = dataContranct.Name,
								AvgValue = dataContranct.AvgValue,
								IntValue = 0
							});
				}
			}
			else
			{
				Columns.Add(m => mdataContranct.StringValue).Titled(dataContranct.Name);
			}
		}
	}
