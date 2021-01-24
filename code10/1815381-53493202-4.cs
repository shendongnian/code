    public class YourClass
    {
       public YourClass()
       {
          Id = Guid.NewGuid();
       }
       [Key]
       public Guid Id { get; set; }
    }
