    class TimeEntry
    {
         public int Id {get; set;}
         // every TimeEntry belongs to exactly one Project using foreign key
         public int ProjectId {get; set;}
         public virtual Project Project {get; set;}
         // every TimeEntry belongs to exactly one Issue using foreign key
         public int IssueId {get; set;}
         public virtual Issue Issue {get; set;}
    }
