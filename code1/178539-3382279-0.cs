    public abstract class Auditable : IAuditable
    {
        public virtual string CreatedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; }
    }
    public class Person : Auditable {}
