    public interface IActivity
    {
      DateTime OccurredOn { get; }
    }
    
    public class Task : IActivity
    {
      public DateTime AssignedOn
      {
        get { /* implemenation */ }
      }
    
      DateTime IActivity.OccurredOn
      {
        get { return AssignedOn; }
      }
    }
    
    public class Message : IActivity
    {
      public DateTime CreatedOn
      {
        get { /* implemenation */ }
      }
    
      DateTime IActivity.OccurredOn
      {
        get { return CreatedOn; }
      }
    }
