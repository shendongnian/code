    public class SomeViewModel
    {
        [RegularExpression("Some bulletproof regex you could google to validate email address", ErrorMessage = "Should not be empty or invalid")]
        public string Email { get; set; }
    }
