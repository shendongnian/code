    public class EnhancedCustomerInput
    {
        public string Title { get; set;}
    
        public bool ResponseOptional { get; set;}
    
        public string CancelLabel { get; set;}
    
        public string SubmitLabel { get; set; }
        public InputType InputType { get; set; }
        public object InputData { get; set; }
    }
    public enum InputType { MultipleChoice, ExplicitAgreement }
