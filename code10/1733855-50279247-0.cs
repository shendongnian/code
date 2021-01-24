    public class CreateStationViewModel
    {
        // You shouldn't have Station ID here as it's creation
        
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name = "State")]
        public int SelectedStateId { get; set; }
        public IDictionary<int, string> AvailableStates { get; set; }
    }
