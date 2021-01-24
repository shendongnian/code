	public class DashboardReport
	{
	    public string Company { get; set; }
	
	    public string VoucherType { get; set; } 
	
	    public string Interval { get; set; }
	
	    public DashboardReportElement CurrentPeriodSummary { get; set; }
	
	    public DashboardReportElement PreviousPeriodSummary { get; set; }
	
	    public string CurrentPeriodNetAmount { get; set; }
	
	    public DashboardReportElement[] CurrentPeriodDetails { get; set; }
	
	    public DashboardReportElement[] PreviousPeriodDetails { get; set; }
	
	    public string GrowthIndicator { get; set; }
		
	    public double Growth { get; set; }
		
	    public DashboardGroupByReport GroupByReport { get; set; }
		
	    public string Error { get; set; }
	
	    public string ToJson()
	    {
	        return JsonConvert.SerializeObject(this);
	    }
	}
 
 
