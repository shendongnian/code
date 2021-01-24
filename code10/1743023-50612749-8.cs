    public class EditClassAViewModel
    {
        [Required]
        public int ClassAId { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name = "Class b")]
        public int SelectedClassBId { get; set; }
        public IDictionary<int, string> AvailableClassBs { get; set; }
    }
