    public partial class Project
    {
        public int ProjectId { get; set; }
        public int Source { get; set; }
        public virtual RSource SourceNavigation { get; set; }
    }
    public partial class RProjectStatus
    {
        public int StatusType { get; set; }
        public int Source { get; set; }
        public virtual RSource SourceNavigation { get; set; }
    }
    public partial class RSource
    {
        public RSource()
        {
            Project = new HashSet<Project>();
            RProjectStatus = new HashSet<RProjectStatus>();
        }
        public int Source { get; set; }
        public virtual ICollection<Project> Project { get; set; }
        public virtual ICollection<RProjectStatus> RProjectStatus { get; set; }
    }
