    public class EnhancedCustomerInput
    {
        public string Title { get; set;}
    
        public bool ResponseOptional { get; set;}
    
        public string CancelLabel { get; set;}
    
        public string SubmitLabel { get; set; }
        public Either<MultipleChoice, ExplicitAgreement> InputData { get; set; }
    }
