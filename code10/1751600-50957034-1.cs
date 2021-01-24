    public class ChartDetails
    {
    	public string IssuesResolved { get; set; }
    
    	public string IssuesRaised { get; set; }
    
    	public ChartDetails()
    	{
    	}
    }
    
    [WebMethod]
    public static List<ChartDetails> GetChartData()
    {
    	List<ChartDetails> dataList = new List<ChartDetails>();
    	
    	// Access SQL Database Data
    	// Assign SQL Data to List<ChartDetails> dataList
    	
    	return dataList;
    }
