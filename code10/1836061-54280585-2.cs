      public class DailyModel
        {
            [Required]
            [RegularExpression("^[A-Z]{3}$", ErrorMessage ="State should be length of 3 and all in Upper Case")]
            public string State { get; set; }
            public int Year { get; set; }
            public int Month { get; set; }
            public int Day { get; set; }
        }
