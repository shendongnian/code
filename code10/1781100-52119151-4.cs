    public class CustomerResult
    {
        public string CompanyStatus { get; set; }
        public OverallResult Result { get; set; }
    	public CustomerResult(){
    	    Result = new OverallResult();
    	}
    }
