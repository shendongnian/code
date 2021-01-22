    public class MyBO
    {
        [NotNullValidator(MessageTemplate = "Cannot be null!",
            Ruleset = "validate_x")]
        [StringLengthValidator(10, RangeBoundaryType.Inclusive, 40, 
            RangeBoundaryType.Inclusive, Ruleset = "validate_x")]
        [RegexValidator(@"^[A-Z][a-z]*\s[A-Z][a-z]*$",
            MessageTemplate = "Not valid!", Ruleset = "validate_x")]
        public string x { get; set; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            MyBO target = new MyBO() { x = null };
            ValidationResults vr = Validation.Validate<MyBO>(target, "validate_x");
            Console.WriteLine(vr.IsValid);
        }
    }
