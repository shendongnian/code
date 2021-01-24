    public class ProjectViewModel
    {
        public Guid Id { get; set; }
        // this could be a Dictionary<string, List<string>> 
        // if there are no duplicate DetailDescription's for a Project 
        public List<KeyValuePair<string, List<string>>> Details { get; set; }
    }
