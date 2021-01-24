	public class StockStatus
	{       
	    public List<int> Origin= new List<int>(){1,2,3,4};
	
	    [Display(Name = "In Transit")]
	    public List<int> InTransit = new List<int>(){ 5};
	    [Display(Name = "Port Louis")]
	    public List<int> PortLouis = new List<int>(){ 6};
	    public List<int> Yard = new List<int>(){ 7};
	    public List<int> Requested = new List<int>(){ 8};
	}
