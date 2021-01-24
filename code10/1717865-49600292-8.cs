    public class Report {
        [Required]
        [Display(Name = "Report File")]
        public HttpPostedFileBase ReportFile { get; set; }
        //... The other fields
    }
