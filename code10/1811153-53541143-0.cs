    public class Person : Base
    {
        // ...
       
        public virtual Company Company { set; get; }    
        public Guid? CompanyId { get; set; }
    }
