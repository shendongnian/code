    public class EntityBase
    {
        public int Id { get; set; }
    
        // sample method that copies member values from other object to current instance
        public abstract void CopyProperties(EntityBase other);
    }
    public class Student : EntityBase
    {
       public int Id { get; set; }
    
       public override void CopyProperties(EntityBase other)
       {
          ...
       }
    }
