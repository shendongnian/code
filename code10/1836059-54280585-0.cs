      public class DailyModel
        {
            [Required]
            [StringLength(3, MinimumLength = 3, ErrorMessage = "State Should be length of 3")]
            [RegularExpression("^[A-Z]",ErrorMessage ="State should be all in Upper Case")]
            public string State { get; set; }
            public int Year { get; set; }
            public int Month { get; set; }
            public int Day { get; set; }
        }
