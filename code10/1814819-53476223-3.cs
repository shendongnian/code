    public class Newtask
    {
        [Key]
        public int TId { get; set; }
        public string Name { get; set; }
        public int Estimated_days_of_work { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<Subtask> Subtasks { get; set; }
    }
    public class Subtask
    {
        [Key]
        public int SId { get; set; }
        public string SubName { get; set; }
        public int SEstimated_days_of_work { get; set; }
        public int NewtaskTId { get; set; }
        public virtual Newtask Newtasks { get; set; } 
        public virtual Substask HasSubtask{get;set;}
    }
