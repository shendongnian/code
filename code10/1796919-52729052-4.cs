    public class CaseInformation
    {
    	public int Id { get; set; }
    
    	public string CaseNumber { get; set; }
    	public string RitNumber { get; set; }
    	public string ApilNumber { get; set; }
    
    	public DateTime Date { get; set; }
    
    	public double CaseInvolvedRevenue { get; set; }
    	public string CaseShortDescription { get; set; }
    	public string CaseUpdateStatus { get; set; }
    
    	public CompanyDetails CompanyDetails { get; set; }
    	public int CompanyDetailsId { get; set; }
    
    	public bool IsValid(out IDictionary<string, string> errors)
    	{
    		errors = new Dictionary<string, string>();
    		if (string.IsNullOrWhiteSpace(CaseNumber) && string.IsNullOrWhiteSpace(RitNumber) &&
    			string.IsNullOrWhiteSpace(ApilNumber))
    		{
    			errors.Add("MyError", "At least one Case, Rit or Apil number is required.");
    		}
    		return errors.Count == 0;
    	}
    }
