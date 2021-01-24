    public class MaxMin
    {
        [Required]
        [RegularExpression("^\\d+(.\\d+){0,1}$", ErrorMessage = "Invalid Value")]
        public string Minimum { get; set; }
        [Required]
        [RegularExpression("^\\d+(.\\d+){0,1}$", ErrorMessage = "Invalid Value")]
        public string Maximum { get; set; }
    }
    public class MaxMinPercentage
    {
        [Required]
        [RegularExpression("^\\d+(.\\d+){0,1}$", ErrorMessage = "Invalid Value")]
        [MaxMinRange("Allowed range (0-100)")]
        public string Minimum { get; set; }
        [Required]
        [RegularExpression("^\\d+(.\\d+){0,1}$", ErrorMessage = "Invalid Value")]
        [MaxMinRange("Allowed range (0-100)")]
        public string Maximum { get; set; }
    }
