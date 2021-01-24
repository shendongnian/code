    public class Report
    {
        public string Contacts { get; set; }
        //other property
    }
    
    public class SaveReportViewModel{
        [Required]
        [Display(Name = "Relevant Contacts")]
        public string Contacts { get; set; }
    }
