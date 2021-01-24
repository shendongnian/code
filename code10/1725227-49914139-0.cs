    public class YourVM
    {
        [Required(ErrorMessage = "...")]
        public int? SelectedYear { get; set; } // nullable
        [Required(ErrorMessage = "...")]
        public int? SelectedWeek { get; set; } // nullable
        public IEnumerable<SelectListItem> YearList { get; set; }
        public IEnumerable<SelectListItem> WeekList { get; set; }
    }
