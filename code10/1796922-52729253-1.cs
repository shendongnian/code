    public class CaseInformation
    {
        public int Id { get; set; }
    
    	[CaseInfoRequired]
        public string CaseNumber { get; set; }
        public string RitNumber { get; set; }
        public string ApilNumber { get; set; }
    
        public DateTime Date { get; set; }
    
        public double CaseInvolvedRevenue { get; set; }
        public string CaseShortDescription { get; set; }
        public string CaseUpdateStatus { get; set; }
    
        public CompanyDetails CompanyDetails { get; set; }
        public int CompanyDetailsId { get; set; }
    }
