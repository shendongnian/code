    public class Update {
        [StringLength(22, MinimumLength = 8)]
        [RegularExpression(@"^\d{8}$|^00\d{6,20}$|^\+\d{6,20}$")]
        public string MobileNumber { get; set; }
    }
