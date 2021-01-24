    public class Project
    {
        public Project(string name, DateTime beginDate) : this(name, beginDate, null) { }
        public Project(string name, DateTime beginDate, DateTime? endDate)
        {
            Name = name;
            BeginDate = beginDate;
            EndDate = endDate;
        }
        public string Name { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public override string ToString()
        {
            return $"{Name}:\t{BeginDate.ToShortDateString()}\t:\t{(EndDate.HasValue ? EndDate.Value.ToShortDateString() : "Present")}";
        }
    }
