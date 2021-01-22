    public class SomeDateModel
    {
        public int MinYears = 18;
        public int MaxYears = 110;
        [Display(Name = "Date of birth", Prompt = "e.g. 01/01/1900")]
        [Remote(action: "ValidateDateBetweenYearsFromNow", controller: "Validation", areaReference: AreaReference.UseRoot, AdditionalFields = "MinYears,MaxYears", HttpMethod = "GET" ,ErrorMessage = "Subject must be over 18")]
        public DateTime? DOB { get; set; }
    }
