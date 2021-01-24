    //[ForeignKey("Id")]
    [ForeignKey("AtendeeId")]  // or just omit this
    public virtual Atendee Atendeed { get; set; }
---
    public class Person {
       [Key]
       public virtual int Id { get; set; }
    
       [ForeignKey("Atendeed")]  // refer to the property
       public virtual int? AtendeeId { get; set; }
    
       public virtual Atendee Atendeed { get; set; }
    }
