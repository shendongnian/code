    public class EnhancedCustomerInput
    {
        public string Title { get; set;}
        public bool ResponseOptional { get; set;}
        public string CancelLabel { get; set;}
        public string SubmitLabel { get; set}
    }
    public class MultipleChoice : EnhancedCustomerInput
    {
        public List<MultipleChoiceOption> Options { get; set; }
        public int MinSelected { get; set; }
        public int MaxSelected { get; set; }
    }
    public class ExplicitAgreement : EnhancedCustomerInput
    {
        public List<BinaryInputOption> Buttons { get; set; }
        public string InputLabel1 { get; set; }
        public string InputLabel2 { get; set; }
    }
