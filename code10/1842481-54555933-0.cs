    public class CreateTeamViewModel
    {
        [Required]
        public string TeamName { get; set; }
    
        public string ProjectName { get; set; }
    
        public string ProjectDescription { get; set; }
    
        [Required]
        public string RepositoryLink { get; set; }
    
        public List<int> SelectedLabels { get; set; } = new List<int>();
    }
