    public class SampleViewModel
    {
        public IList<IncidentListmodel> IncidentListmodel = new List<IncidentListmodel>();
    }
    
    public class IncidentListmodel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }
    }
