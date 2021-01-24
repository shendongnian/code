    public class BaseEntity
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set;}
    }
    
    public class SomeClass : BaseEntity
    {
        ...
    }
