    public class Report
    {
        public string Contacts { get; set; }
        //other property
    }
    
    public class CreateReportViewModel {
        [Required]
        [Display(Name = "Relevant Contacts")]
        public string Contacts { get; set; }
        
        //your Contacts List
    }
