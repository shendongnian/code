    // Arbitrary class to hold required data from SQL Database
    public class ChartDetails
    {
    	public string IssuesResolved { get; set; }
    
    	public string IssuesRaised { get; set; }
    
    	public ChartDetails()
    	{
    	}
    }
    
    // Method that will be called by JQuery script
    [WebMethod]
    public static List<ChartDetails> GetChartData()
    {
    	List<ChartDetails> dataList = new List<ChartDetails>();
    	
    	// Access SQL Database Data
    	// Assign SQL Data to List<ChartDetails> dataList
    	
    	return dataList;
    }
