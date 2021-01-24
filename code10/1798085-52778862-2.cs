    public List<SalesDataDTO> GetReportData()
    {
    	// 1. Define date range
    	DateTime fromDate = DateTime.Now.Date;
    	DateTime toDate = DateTime.Now.Date.AddDays(-30);
    
    	// 2. create object to store final result
    	List<SalesDataDTO> saleDataList = new List<SalesDataDTO>();
    
    	// 3. create basic data
    	foreach (DateTime day in EachDay(fromDate, toDate))
    	{
    		saleDataList.Add(new SalesDataDTO { Date = day });
    	}
    
    	// 4. get actual data from db
    	List<SalesDataDTO> actualReportData = allData.OrderBy(x => x.DataDate.Value.Date)
    								.Select(item =>
    									new SalesDataDTO
    									{
    									 Date = item.DataDate.Value.ToString("yyyy-MM-dd"),
    									 Sales = (int)item.SalesForDay,
    									 Revenue = (int?)item.RevenueForDay.Value
    									}); 
    
    	// 5. a bit customization
    	saleDataList.ForEach(record =>
    	{
    		var actualData = actualReportData.FirstOrDefault(x => x.Date.Date == record.Date.Date);
    		if (actualData != null)
    		{
    			record.Sales = actualData.Sales;
    			record.Revenue = actualData.Revenue;
    		}
    	});
    
    	// 6. return data
    	return saleDataList;
    }
