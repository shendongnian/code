    public class TrainingItem 
    {
      // ... properties for Training
      public virtual ICollection<AttendeeTrainingEmployeeTrainingItem> Attendees {get;set;} = new List<AttendeeTrainingEmployeeTrainingItem>();
    
      public virtual ICollection<WaitingListTrainingEmployeeTrainingItem> WaitingList {get;set;} = new List<WaitingListTrainingEmployeeTrainingItem>();  
    }
    
    public class TrainingEmployee
    {
        // ... properties for Employee
        public virtual ICollection<AttendeeTrainingEmployeeTrainingItem> AttendingTrainings {get;set;} = new List<AttendeeTrainingEmployeeTrainingItem>();
        public virtual ICollection<WaitingListTrainingEmployeeTrainingItem> AwaitingTrainings {get;set;} = new List<WaitingListTrainingEmployeeTrainingItem>();
    }
    public abstract class TrainingEmployeeTrainingItem
    {
        public int TrainingEmployeeId {get;set;}
        public virtual TrainingEmployee TrainingEmployee {get;set;}
    
        public int TrainingItemId {get;set;}
        public virtual TrainingItem TrainingItem {get;set;}
    }
    public class AttendeeTrainingEmployeeTrainingItem : TrainingEmployeeTrainingItem
    {
    }
    public class WaitingListTrainingEmployeeTrainingItem : TrainingEmployeeTrainingItem
    {
    }
    // this is my model creating method in db context
    protected override void OnModelCreating(ModelBuilder builder)
    {
        // many-to-many
        builder.Entity<AttendeeTrainingEmployeeTrainingItem>()
            .HasKey(x => new { x.TrainingEmployeeId, x.TrainingItemId });
        builder.Entity<WaitingListTrainingEmployeeTrainingItem>()
            .HasKey(x => new { x.TrainingEmployeeId, x.TrainingItemId });
    }
