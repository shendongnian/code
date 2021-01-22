    public class Task
    {
      string Name;
      public static bool operator ==(Task t1, Task t2)
      { 
        if ((object)t1 == null || (object)t2 == null)
        {
          return (object)t1 == null && (object)t2 == null;
        }
        
        return t1.Name == t2.Name && t1.GetType() == t2.GetType(); }
      public virtual bool Equals(Task t2)
      {
         return this == t2;
      }
    }
    public class TaskA : Task
    {
      int aThing;
      public static bool operator ==(TaskA t1, TaskA t2)
      { 
        if ((object)t1 == null || (object)t2 == null)
        {
          return (object)t1 == null && (object)t2 == null;
        }
        
        return (Task)t1 == (Task)t2 && t1.aThing == t2.aThing;
      }
      public override bool Equals(Task t2)
      {
        return this == t2 as TaskA;
      }
    }
